using Godot;
using System;

public class Global {
	private const string packedScenesPath = "res://Nodes//";

	public static void LoadPackedScene (Node2D node, string name) {
		const string fileType = ".tscn";

		if(!name.Contains(fileType)) {
			name += fileType;
		}
		var scene = ResourceLoader.Load<PackedScene>(packedScenesPath+name).Instantiate();
		node.AddChild(scene);
	}
	public static void LoadPackedScene (Node2D node, PackedScene packedScene) {
		var scene = packedScene.Instantiate();
		node.AddChild(scene);
	}
}
