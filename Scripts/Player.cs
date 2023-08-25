using Godot;
using System;

public partial class Player : Creature {
	[Export] public float JumpVelocity = -40.0f;

	public override void _Ready () {
		sprite.Frame = 0;
	}
	public override void _PhysicsProcess(double delta)
	{
		bool gameStateDefault = GameScene.Instance.CurrentState == GameScene.State.DEFAULT;
		Vector2 velocity = Velocity;

		velocity = HandleGravity(delta, velocity);

		if(gameStateDefault) {
			switch (CurrentState) {
				case State.CLIMBING : velocity = HandleClimbing(velocity); break;
				case State.DEAD : 	  velocity = HandleDeath(velocity); break;
				default : 			  velocity = HandleMovement(velocity); break;
			}
		}
		Velocity = velocity;
		MoveAndSlide();
	}
	private Vector2 HandleGravity (double delta, Vector2 velocity) {
		if(CurrentState != State.CLIMBING) {
			// Add the gravity.
			if (!IsOnFloor()) {
				velocity.Y += gravity * (float) delta;
			}
		}
		return velocity;
	}
	private Vector2 HandleClimbing (Vector2 velocity) {
		if (!StartedClimbing && IsOnFloor()) {
			CurrentState = State.DEFAULT;
		} else {
			Vector2 direction = Vector2.Zero;

			if (Input.IsActionPressed("player_move_left")) {
				direction.X--;
			} else if (Input.IsActionPressed("player_move_right")) {
				direction.X++;
			} else if (Input.IsActionPressed("player_move_up")) {
				direction.Y--;
			} else if (Input.IsActionPressed("player_move_down")) {
				direction.Y++;
			}
			if (direction != Vector2.Zero) {
				StartedClimbing = false;
				velocity.X = direction.X * Speed;
				velocity.Y = direction.Y * Speed;
			} else {
				velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
				velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
			}
		}

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
	private Vector2 HandleDeath (Vector2 velocity) {
		velocity.X = 0;
		return velocity;
	}
	public override void Kill () {
		GameScene.Instance.SetGameOverState();
		CurrentState = State.DEAD;
		moveDirection = MoveDirection.NONE;
		animationPlayer.Play("death");
	}
}
