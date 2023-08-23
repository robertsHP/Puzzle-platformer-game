using Godot;
using System;
using Godot.Collections;
using System.Diagnostics;

public partial class PressurePad : Area2D
{
	[Export] public Array<Trap> traps;

	public void TriggerTraps () {
		if(traps.Count != 0) {
			foreach (Trap trap in traps) {
				trap.Trigger();
			}
		}
	}
	public void _on_body_entered (Node2D node) {
		if (node is CharacterBody2D) {
			TriggerTraps();
		}
	}
	public void _on_body_exited (Node2D node) {
		if (node is CharacterBody2D) {
			TriggerTraps();
		}
	}
}
