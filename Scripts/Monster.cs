using Godot;
using System;

public partial class Monster : CharacterBody2D
{
	public enum Direction {LEFT, RIGHT}

	[Export] public Sprite2D sprite;
	[Export] public AnimationPlayer animationPlayer;
	[Export] public float Speed = 40.0f;
	[Export] public Direction direction;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	private float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	private float moveDirX;

	public override void _Ready () {
		SetDirection(direction);
		animationPlayer.Play("walk");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y += gravity * (float) delta;

		velocity.X = moveDirX * Speed;

		Velocity = velocity;
		KinematicCollision2D collisionData = MoveAndCollide(
			new Vector2(Velocity.X * (float) delta, Velocity.Y * (float) delta));

		if(collisionData != null) {
			// GameScene.Instance.tileMap.GetCellTileData();

			// var cell = GameScene.Instance.tileMap.WorldToMap(collisionData.GetPosition() - collisionData.GetNormal());
			// var tile_id = tilemap.get_cellv(cell);
			SetDirection(direction == Direction.LEFT ? Direction.LEFT : Direction.RIGHT);
		}
	}
	private void SetDirection (Direction newDirection) {
		direction = newDirection;
		moveDirX = direction == Direction.LEFT ? -1 : 1;
		Scale = new Vector2(
			Scale.Y * (direction == Direction.LEFT ? -1 : 1),
			Scale.Y
		);
	}
	public void _on_area_2d_body_entered (Node2D node) {
		if (node is Player) {
			Player player = (Player) node;
			player.Kill();
		}
	}
}
