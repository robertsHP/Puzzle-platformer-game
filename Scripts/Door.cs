using Godot;
using System;

public partial class Door : Area2D {
    [Export] public AnimationPlayer animationPlayer;

    private Player player;
	public override void _Process(double delta) {
        if(GameScene.Instance.CurrentState == GameScene.State.DEFAULT) {
            if(player != null) {
                if (Input.IsActionPressed("player_interact")) {
                    animationPlayer.Play("open");
                    GameScene.Instance.SetWinState();
                }
            }
        }
	}
	public void _on_body_entered (Node2D node) {
        if(node is Player)
		    player = (Player) node;
	}
	public void _on_body_exited (Node2D node) {
		player = null;
	}
}
