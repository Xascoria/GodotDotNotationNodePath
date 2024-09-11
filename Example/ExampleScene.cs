using Godot;
using System;

public class ExampleScene : Node2D
{
    private _ExampleSceneNodePaths nodePaths;
    public override void _Ready()
    {
        nodePaths = new _ExampleSceneNodePaths(this);

        GD.Print(nodePaths.RootNodeName.SecondChild.Timer.GetNode());
        GD.Print(nodePaths.RootNodeName.Player.CollisionShape2D.GetPath());
        GD.Print(nodePaths.RootNodeName.Player.GetNode());
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}
