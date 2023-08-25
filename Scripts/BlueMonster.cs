using Godot;
using System;

public partial class BlueMonster : Creature {
	public override void _Ready () {
		SetDirection(moveDirection);
		animationPlayer.Play("walk");
	}

	public override void _PhysicsProcess(double delta)
	{
		bool monsterAlive = CurrentState != State.DEAD;
		bool gameStateDefault = GameScene.Instance.CurrentState == GameScene.State.DEFAULT;

		if(monsterAlive && gameStateDefault) {
			Vector2 velocity = Velocity;

			// Add the gravity.
			if (!IsOnFloor())
				velocity.Y += gravity * (float) delta;

			float moveDirX = (float) moveDirection;
			velocity.X = moveDirX * Speed;

			Velocity = velocity;
			MoveAndSlide();
		}
	}
	public void _on_body_area_2d_body_entered (Node2D node) {
		bool monsterAlive = CurrentState != State.DEAD;

		if (monsterAlive && node is Player) {
			Player player = (Player) node;
			player.Kill();
		}
	}
	public void _on_turn_area_2d_body_entered (Node2D node) {
		if (TurnArea2DCollisionValidation(node)) {
			SetDirection((MoveDirection)(-(int)moveDirection));
		}
	}
}
