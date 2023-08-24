using Godot;
using System;

public partial class GameScene : Node2D {
	public static GameScene Instance;
	public enum State {
		DEFAULT, GAMEOVER, WIN
	}

	[Export] public TileMap tileMap;
	[Export] public Player player;
	
	public State CurrentState {get; set;}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		Instance = this;
		CurrentState = State.DEFAULT;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
		if(CurrentState != State.DEFAULT) {
			if (Input.IsActionPressed("game_reset")) {
				Reset();
			}
		}
		// GD.Print(CurrentState);
	}
	public void Reset () {
		Global.ChangeScene(this, "GameScene");
	}
	public void SetGameOverState () {
		CurrentState = GameScene.State.GAMEOVER;
	}
	public void SetWinState () {
		CurrentState = GameScene.State.WIN;
	}
}
