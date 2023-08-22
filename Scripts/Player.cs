using Godot;
using System;

public partial class Player : Godot.CharacterBody2D
{
	[Export] public Sprite2D sprite;
	[Export] public AnimationPlayer animationPlayer;
	[Export] public float Speed = 40.0f;
	[Export] public float JumpVelocity = -30.0f;

	private bool dead = false;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	private float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _Ready () {
		animationPlayer.Play("idle");
	}
	public override void _PhysicsProcess(double delta)
	{
		if(!dead) {
			Velocity = Movement(delta, Velocity);
			MoveAndSlide();
		}
	}
	private Vector2 Movement(double delta, Vector2 prevVelocity)
	{
		Vector2 velocity = prevVelocity;

		// Add the gravity.
		if (!IsOnFloor()) {
			velocity.Y += gravity * (float)delta;
		} else {
			// Handle Jump.
			if (Input.IsActionJustPressed("player_jump")) {
				animationPlayer.Play("jump");
				velocity.Y = JumpVelocity;
			}
		}

		// Get the input direction and handle the movement/deceleration.
		Vector2 direction = Vector2.Zero;
		if (Input.IsActionPressed("player_move_left")) {
			direction.X -= 1;
			sprite.FlipH = true;
		} else if (Input.IsActionPressed("player_move_right")) {
			direction.X += 1;
			sprite.FlipH = false;
		}
		if (direction != Vector2.Zero) {
			if (animationPlayer.CurrentAnimation != "jump")
				animationPlayer.Play("walk");
			velocity.X = direction.X * Speed;
		} else {
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		return velocity;
	}
	public void Kill () {
		dead = true;
		animationPlayer.Play("death");
	}
}
