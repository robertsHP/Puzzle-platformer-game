using Godot;
using System;

public partial class Player : Creature {
	[Export] public float JumpVelocity = -40.0f;

	public override void _Ready () {
		sprite.Frame = 0;
	}
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor()) {
			velocity.Y += gravity * (float)delta;
		}

		bool playerAlive = CurrentState != State.DEAD;
		bool gameStateDefault = GameScene.Instance.CurrentState == GameScene.State.DEFAULT;

		if(playerAlive || gameStateDefault) {
			switch (CurrentState) {
				case State.CLIMBING :
					velocity = HandleClimbing(velocity); break;
				default :
					velocity = HandleMovement(velocity); break;
			}
		} else {
			velocity.X = 0;
		}
		Velocity = velocity;
		MoveAndSlide();
	}
	private Vector2 HandleClimbing (Vector2 velocity) {
		
		return velocity;
	}
	private Vector2 HandleMovement (Vector2 velocity) {
		if (IsOnFloor()) {
			if(!animationPlayer.IsPlaying())
				sprite.Frame = 0;
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
			if (IsOnFloor())
				animationPlayer.Play("walk");
			velocity.X = direction.X * Speed;
		} else {
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}
		return velocity;
	}
	public override void Kill () {
		GameScene.Instance.SetGameOverState();
		CurrentState = State.DEAD;
		moveDirection = MoveDirection.NONE;
		animationPlayer.Play("death");
	}
}
