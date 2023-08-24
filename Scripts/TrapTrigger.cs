using Godot;
using Godot.Collections;
using System;

public partial class TrapTrigger : Area2D {
	[Export] public Array<Trap> traps;
	[Export] public Sprite2D sprite;

	public void TriggerTraps () {
		if(traps.Count != 0) {
			foreach (Trap trap in traps) {
				trap.Trigger();
			}
		}
	}
}
