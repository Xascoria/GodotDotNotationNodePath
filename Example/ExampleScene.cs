using Godot;
using System;

public class ExampleScene : Node2D
{
    private _ExampleSceneNodePaths nodePaths = new _ExampleSceneNodePaths();
    public override void _Ready()
    {
        GD.Print(nodePaths.RootNodeName.SecondChild.Timer.GetNode(this));
        GD.Print(nodePaths.RootNodeName.Player.CollisionShape2D.GetPath());
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}
