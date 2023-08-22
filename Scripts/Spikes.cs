using Godot;
using System;
using System.Collections;

public partial class Spikes : Trap
{
	[Export] public Sprite2D sprite;
	[Export] public AnimationPlayer animationPlayer;
	[Export] public bool TurnedOnWhenGameLaunched;

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
	public override void _Process (double delta) {
		if (animationPlayer.IsPlaying()) {

		}
	}

	public override void Trigger () {
		on = !on;
		animationPlayer.Play(on ? "On" : "Off");
	}

	public void _on_body_entered (Node2D node) {
		if (node.GetType() == typeof(Player)) {
			if(On) {
				Player player = (Player) node;
				player.Kill();
			}
		}
	}
}
