using Godot;
using System;

public partial class TrapDoor : Trap {
    [Export] public StaticBody2D staticBody;
	[Export] public bool open = true;

	public override void _Ready () {
		triggerdelegate = Open;
	}

	public void Open () {
		open = !open;
        staticBody.SetCollisionLayerValue(1, open);
        staticBody.SetCollisionMaskValue(1, open);
		sprite.Frame += (open) ? -1 : 1;
	}
}
