using Godot;
using System;

public partial class Lava : Area2D {
    [Export] public AnimationPlayer animationPlayer;
	public override void _Ready () {
		animationPlayer.Play("idle");
	}
	public void _on_body_entered (Node2D node) {
		if (node is Creature) {
			Creature creature = (Creature) node;
			creature.Kill();
		}
	}
}
