using Godot;
using System;
using System.Collections;
using System.Collections.Generic;


public partial class Spikes : Trap
{
	[Export] public bool TurnedOnWhenGameLaunched;
	[Export] public AnimationPlayer animationPlayer;

	private bool on;
	public bool On {
		get { 
			return on;
		}
		set { 
			animationPlayer.Play(value ? "On" : "Off");
			on = value;
		}
	}
	private List<Creature> creatures = new List<Creature>();

	public override void _Ready () {
		On = TurnedOnWhenGameLaunched;
		triggerdelegate = Raise;
	}
	public override void _Process (double delta) {
		if(On && creatures.Count != 0) {
			KillCreatures();
		}
	}
	private void KillCreatures () {
		foreach (Creature creature in creatures) {
			if(creature.CurrentState != Creature.State.DEAD)
				creature.Kill();
		}
	}

	public void Raise () {
		On = !On;
		animationPlayer.Play(On ? "On" : "Off");
	}

	public void _on_body_entered (Node2D node) {
		if (node is Creature) {
			creatures.Add((Creature)node);
		}
	}
	public void _on_body_exited (Node2D node) {
		if (node is Creature) {
			Creature currentCreature = (Creature) node;
			if(creatures.Contains(currentCreature)) {
				creatures.Remove(currentCreature);
			}
		}
	}
}
