using Godot;
using System;

public partial class Ladder : Area2D {
	private Node2D nodeEntered;

	public override void _Process(double delta) {
		if(GameScene.Instance.CurrentState == GameScene.State.DEFAULT) {
			if(nodeEntered != null) {
				if (nodeEntered is Player) {
					if (Input.IsActionJustPressed("player_move_up")) {
                        
					}
				}
			}
		}
	}

	public void _on_body_entered (Node2D node) {
		nodeEntered = node;
	}
	public void _on_body_exited (Node2D node) {
		nodeEntered = null;
	}
}
