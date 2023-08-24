using Godot;
using System;

public partial class Dispenser : Trap {
	[Export] public PackedScene packedScene;

	public override void _Ready () {
        triggerdelegate = Shoot;
    }
	public void Shoot () {
		if(GameScene.Instance.CurrentState == GameScene.State.DEFAULT)
			Global.LoadPackedScene(this, packedScene);
	}
}
