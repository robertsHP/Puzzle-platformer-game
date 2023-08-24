using Godot;
using Godot.Collections;
using System;

public partial class Button : TrapTrigger {
	private Node2D nodeEntered;
    private bool triggered = false;

	public override void _Process(double delta) {
		if(GameScene.Instance.CurrentState == GameScene.State.DEFAULT) {
			if(nodeEntered != null) {
				if (nodeEntered is Player) {
					if (Input.IsActionJustPressed("player_interact")) {
						triggered = !triggered;
						sprite.Frame += (triggered) ? 1 : -1;
						TriggerTraps();
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
