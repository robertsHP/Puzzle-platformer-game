using Godot;
using System;

public partial class Bullet : Area2D {
	public bool Launched { get; set; }

	public override void _Process(double delta)	{
		if(Launched) {
			Position += new Vector2(0, 1);
			GD.Print(Position);
		}
	}
	public void _on_body_entered (Node2D node) {
		if (node.GetType() == typeof(Player)) {
			Player player = (Player) node;
			player.Kill();
		}
	}
	public void _on_area_entered (Area2D area) {
		GD.Print("fuck");
	}
}
