using Godot;
using System;

public partial class Ball : CharacterBody2D {
	public enum MoveDirection : int {LEFT = -1, RIGHT = 1}

    private float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	private Creature creaturePushingRight, creaturePushingLeft;

	public override void _PhysicsProcess(double delta) {
		if(GameScene.Instance.CurrentState == GameScene.State.DEFAULT) {
			Vector2 velocity = Velocity;

			// Add the gravity.
			if (!IsOnFloor())
				velocity.Y += gravity * (float) delta;

			Vector2 direction = Vector2.Zero;
			float speed = 0f;

			if(creaturePushingRight != null) {
				direction.X = (float) MoveDirection.RIGHT;
				speed = creaturePushingRight.Speed;
			} else if (creaturePushingLeft != null) {
				direction.X = (float) MoveDirection.LEFT;
				speed = creaturePushingLeft.Speed;			
			}

			if (direction != Vector2.Zero) {
				velocity.X = direction.X * speed;
			} else {
				velocity.X = 0;
			}

			Velocity = velocity;
			MoveAndSlide();
		}
	}
	public void _on_left_area_2d_body_entered (Node2D node) {
		if (node is Creature) {
			creaturePushingRight = (Creature) node;
		}
	}
	public void _on_right_area_2d_body_entered (Node2D node) {
		if (node is Creature) {
			creaturePushingLeft = (Creature) node;
		}
	}
	public void _on_left_area_2d_body_exited (Node2D node) {
		creaturePushingRight = null;
	}
	public void _on_right_area_2d_body_exited (Node2D node) {
		creaturePushingLeft = null;
	}
}
