using Godot;
using System;

public partial class Dispenser : Trap
{
	[Export] public Bullet bullet;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
		
	}
	public override void Trigger () {
		
	}
	public void _on_timer_timeout () {
		GD.Print("Gamer");
		Bullet newBullet = (Bullet) bullet.Duplicate();
		newBullet.Launched = true;
	}
}
