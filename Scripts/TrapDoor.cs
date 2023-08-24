using Godot;
using System;

public partial class TrapDoor : Trap {
    [Export] public CollisionShape2D collisionShape;

	public override void _Ready () {
        triggerdelegate = Open;
    }

    public void Open () {
        sprite.Frame++;
        collisionShape.Disabled = true;
    }
}
