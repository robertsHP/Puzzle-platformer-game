using Godot;
using System;

public partial class TrapTimer : Timer {
	[Export] public Trap trap;

	public void _on_timer_timeout () {
		trap.Trigger();
	}
}
