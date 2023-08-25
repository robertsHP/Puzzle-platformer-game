using Godot;
using System;

public partial class TrapDoor : Trap {
    [Export] public StaticBody2D staticBody;
	[Export] public bool closed = true;

	public override void _Ready () {
		triggerdelegate = TriggerDoor;
		if(!closed) {
			triggerdelegate();
		}
	}

	public void TriggerDoor () {
		closed = !closed;
        staticBody.SetCollisionLayerValue(1, closed);
        staticBody.SetCollisionMaskValue(1, closed);
		sprite.Frame += (closed) ? -1 : 1;
	}
}
