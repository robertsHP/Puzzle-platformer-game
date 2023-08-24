using Godot;
using System;

public partial class Trap : Area2D
{
	[Export] public Sprite2D sprite;
    public virtual void Trigger () {}
}