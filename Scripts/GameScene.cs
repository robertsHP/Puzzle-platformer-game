using Godot;
using System;

public partial class GameScene : Node2D {
	public static GameScene Instance;
	public enum State {
		DEFAULT, GAMEOVER
	}

	[Export] public TileMap tileMap;
	
	public State CurrentState {get; set;}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		if(Instance == null) {
			Instance = this;
			CurrentState = State.DEFAULT;
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {

	}
}
