using Godot;
using System;

public partial class Creature : CharacterBody2D {
	public enum MoveDirection : int {LEFT = -1, NONE = 0, RIGHT = 1}

	public enum State : int {
		DEFAULT,
		DEAD,
		CLIMBING
	}

	[Export] public Sprite2D sprite;
	[Export] public AnimationPlayer animationPlayer;
	[Export] public MoveDirection moveDirection;
	[Export] public CollisionShape2D collisionShape2D;
	[Export] public float Speed = 60.0f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	protected float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	public State CurrentState {get; set;} = State.DEFAULT;
	public bool StartedClimbing {get; set;} = false;

	public virtual void Kill () {
		CurrentState = State.DEAD;
		collisionShape2D.Shape = null;
		animationPlayer.Play("death");
	}
	public void SetDirection (MoveDirection newDirection) {
		moveDirection = newDirection;
		Scale = new Vector2(
			Scale.Y * (int) moveDirection,
			Scale.Y
		);
	}
	protected bool TurnArea2DCollisionValidation (Node2D node) {
		bool isTileMap = node is TileMap;
		bool isBall = node is Ball;
		bool isPlaceHolderBody = node is PlaceHolderStaticBody;
		bool isMonster = node is BlueMonster || node is GreenMonster;

		return isTileMap || isBall || isPlaceHolderBody || isMonster;
	}
}
