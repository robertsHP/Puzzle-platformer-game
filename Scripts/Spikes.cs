using Godot;
using System;
using System.Collections;

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

	public override void _Ready () {
		On = TurnedOnWhenGameLaunched;
	}
	public override void Trigger () {
		On = !On;
		animationPlayer.Play(On ? "On" : "Off");
	}

	public void _on_body_entered (Node2D node) {
		if (node is Creature) {
			if(On) {
				Creature creature = (Creature) node;
				creature.Kill();
			}
		}
	}
}
