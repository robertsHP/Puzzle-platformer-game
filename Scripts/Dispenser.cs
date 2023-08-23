using Godot;
using System;

public partial class Dispenser : Trap {
	[Export] public PackedScene bulletPackedScene;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
		
	}
	public override void Trigger () {
		
	}
	public void _on_timer_timeout () {
		if(GameScene.Instance.CurrentState == GameScene.State.DEFAULT)
			Global.LoadPackedScene(this, bulletPackedScene);
	}
}
