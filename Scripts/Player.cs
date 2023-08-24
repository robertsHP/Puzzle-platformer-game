using Godot;
using System;

public partial class Player : Creature
{
	[Export] public float Speed = 40.0f;
	[Export] public float JumpVelocity = -30.0f;

	public override void _Ready () {
		animationPlayer.Play("idle");
	}
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor()) {
			velocity.Y += gravity * (float)delta;
		}

		if(alive && GameScene.Instance.CurrentState == GameScene.State.DEFAULT) {
			if (IsOnFloor()) {
				// Handle Jump.
				if (Input.IsActionJustPressed("player_jump")) {
					animationPlayer.Play("jump");
					velocity.Y = JumpVelocity;
				}
			}
			// Get the input direction and handle the movement/deceleration.
			Vector2 direction = Vector2.Zero;
			if (Input.IsActionPressed("player_move_left")) {
				if(moveDirection != MoveDirection.LEFT)
					SetDirection(MoveDirection.LEFT);
				direction.X += (float) moveDirection;
			} else if (Input.IsActionPressed("player_move_right")) {
				if(moveDirection != MoveDirection.RIGHT)
					SetDirection(MoveDirection.RIGHT);
				direction.X += (float) moveDirection;
			}
			if (direction != Vector2.Zero) {
				if (animationPlayer.CurrentAnimation != "jump")
					animationPlayer.Play("walk");
				velocity.X = direction.X * Speed;
			} else {
				velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			}
		}
		Velocity = velocity;
		MoveAndSlide();
	}
	public override void Kill () {
		GameScene.Instance.CurrentState = GameScene.State.GAMEOVER;
		alive = false;
		animationPlayer.Play("death");
	}
}
