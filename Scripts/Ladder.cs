using Godot;
using System;

public partial class Ladder : Area2D {
	private Creature creatureEntered;

	public override void _Process(double delta) {
		if(GameScene.Instance.CurrentState == GameScene.State.DEFAULT) {
			if(creatureEntered != null) {
                if (Input.IsActionJustPressed("player_move_up")) {
                    creatureEntered.GlobalPosition += new Vector2(0, -1);
                    creatureEntered.CurrentState = Creature.State.CLIMBING;
                    creatureEntered.StartedClimbing = true;
                }
			}
		}
	}

	public void _on_body_entered (Node2D node) {
        if(node is Player) {
		    creatureEntered = (Creature) node;
        }
	}
	public void _on_body_exited (Node2D node) {
        if(node is Player) {
            if(creatureEntered.CurrentState == Creature.State.CLIMBING) {
                creatureEntered.CurrentState = Creature.State.DEFAULT;
            }
            creatureEntered = null;
        }
	}
}
