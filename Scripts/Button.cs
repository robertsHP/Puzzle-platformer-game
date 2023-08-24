using Godot;
using Godot.Collections;
using System;

public partial class Button : TrapTrigger {
	private Node2D nodeEntered;
    private bool triggered;

	public override void _Process(double delta) {
		if(!triggered && nodeEntered != null) {
			if (nodeEntered is Player) {
				if (Input.IsActionPressed("player_interact")) {
					sprite.Frame++;
					TriggerTraps();
                    triggered = true;
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
