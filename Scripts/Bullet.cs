using Godot;
using System;

public partial class Bullet : Area2D {
	public override void _Process(double delta)	{
		if(GameScene.Instance.CurrentState == GameScene.State.DEFAULT) {
			Position += new Vector2(0, -1);
		}
	}
	public void _on_body_entered (Node2D node) {
		if (node is Player) {
			Player player = (Player) node;
			player.Kill();
		} else {
			QueueFree();
		}
	}
}
