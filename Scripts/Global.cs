using Godot;
using System;

public class Global {
	private const string resPath = "res://";

	private static string CheckAndAddMissingString (string str, string missingStr) {
		if(!str.Contains(missingStr)) {
			str += missingStr;
		}
		return str;
	}
	public static void LoadPackedScene (Node2D node, string name) {
		name = CheckAndAddMissingString(name, ".tscn");
		var scene = ResourceLoader.Load<PackedScene>(resPath+"PackedScenes/"+name).Instantiate();
		node.AddChild(scene);
	}
	public static void LoadPackedScene (Node2D node, PackedScene packedScene) {
		var scene = packedScene.Instantiate();
		node.AddChild(scene);
	}
	public static void ChangeScene (Node2D node, string name) {
		name = CheckAndAddMissingString(name, ".tscn");
		GD.Print(resPath+"Scenes//"+name);
		node.GetTree().ChangeSceneToFile(resPath+"Scenes//"+name);
	}
}
