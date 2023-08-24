using Godot;
using System;

public partial class TrapTimer : Timer {
	[Export] public Trap trap;

	public void _on_timeout () {
		if(trap.triggerdelegate != null)
			trap.triggerdelegate();
	}
}
