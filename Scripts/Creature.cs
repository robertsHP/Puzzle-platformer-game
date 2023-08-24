using Godot;
using System;

public partial class Creature : CharacterBody2D {
	public enum MoveDirection : int {LEFT = -1, RIGHT = 1}

	[Export] public Sprite2D sprite;
	[Export] public AnimationPlayer animationPlayer;
	[Export] public MoveDirection moveDirection;
	[Export] public CollisionShape2D collisionShape2D;
	[Export] public float Speed = 40.0f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	protected float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	protected bool alive = true;

	public virtual void Kill () {
		alive = false;
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
}
