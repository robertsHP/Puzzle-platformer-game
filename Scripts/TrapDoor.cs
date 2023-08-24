using Godot;
using System;

public partial class TrapDoor : Trap {
    [Export] public CollisionShape2D collisionShape;
    public override void Trigger () {
        sprite.Frame++;
        collisionShape.Disabled = true;
    }
}
