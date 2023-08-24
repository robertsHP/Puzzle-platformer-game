using Godot;
using Godot.Collections;

public partial class PressurePad : TrapTrigger {
	public void _on_body_entered (Node2D node) {
		if (node is CharacterBody2D) {
			sprite.Frame++;
			TriggerTraps();
		}
	}
	public void _on_body_exited (Node2D node) {
		if (node is CharacterBody2D) {
			sprite.Frame--;
			TriggerTraps();
		}
	}
}
