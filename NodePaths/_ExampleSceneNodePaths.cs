using Godot;
using System;

public class _ExampleSceneNodePaths
{
    private static Node anyNodeRef;
    public _ExampleSceneNodePaths_RootNodeName RootNodeName = new _ExampleSceneNodePaths_RootNodeName();
    public _ExampleSceneNodePaths(Node anyNode)
    {
        anyNodeRef = anyNode;
    }
    public class _ExampleSceneNodePaths_RootNodeName : IAutomatedNodePath<ExampleScene>
    {
        public _ExampleSceneNodePaths_RootNodeName_FirstChild FirstChild = new _ExampleSceneNodePaths_RootNodeName_FirstChild();
        public _ExampleSceneNodePaths_RootNodeName_SecondChild SecondChild = new _ExampleSceneNodePaths_RootNodeName_SecondChild();
        public _ExampleSceneNodePaths_RootNodeName_Child3 Child3 = new _ExampleSceneNodePaths_RootNodeName_Child3();
        public _ExampleSceneNodePaths_RootNodeName_Player Player = new _ExampleSceneNodePaths_RootNodeName_Player();
        public _ExampleSceneNodePaths_RootNodeName_UICanvas UICanvas = new _ExampleSceneNodePaths_RootNodeName_UICanvas();
        public string GetPath() { throw new Exception("GetPath() called on Root disallowed"); }
        public ExampleScene GetNode() { return (ExampleScene) anyNodeRef.GetTree().CurrentScene; }
    }

    public class _ExampleSceneNodePaths_RootNodeName_FirstChild : IAutomatedNodePath<FirstChild>
    {
        public _ExampleSceneNodePaths_RootNodeName_FirstChild_Sprite Sprite = new _ExampleSceneNodePaths_RootNodeName_FirstChild_Sprite();
        public _ExampleSceneNodePaths_RootNodeName_FirstChild_Sprite2 Sprite2 = new _ExampleSceneNodePaths_RootNodeName_FirstChild_Sprite2();
        public string GetPath() {return "FirstChild";}
        public FirstChild GetNode() { return anyNodeRef.GetTree().CurrentScene.GetNode<FirstChild>(GetPath()); }
    }

    public class _ExampleSceneNodePaths_RootNodeName_FirstChild_Sprite : IAutomatedNodePath<Sprite>
    {
        public string GetPath() {return "FirstChild/Sprite";}
        public Sprite GetNode() { return anyNodeRef.GetTree().CurrentScene.GetNode<Sprite>(GetPath()); }
    }

    public class _ExampleSceneNodePaths_RootNodeName_FirstChild_Sprite2 : IAutomatedNodePath<Sprite>
    {
        public string GetPath() {return "FirstChild/Sprite2";}
        public Sprite GetNode() { return anyNodeRef.GetTree().CurrentScene.GetNode<Sprite>(GetPath()); }
    }

    public class _ExampleSceneNodePaths_RootNodeName_SecondChild : IAutomatedNodePath<Node>
    {
        public _ExampleSceneNodePaths_RootNodeName_SecondChild_Here Here = new _ExampleSceneNodePaths_RootNodeName_SecondChild_Here();
        public _ExampleSceneNodePaths_RootNodeName_SecondChild_Is Is = new _ExampleSceneNodePaths_RootNodeName_SecondChild_Is();
        public _ExampleSceneNodePaths_RootNodeName_SecondChild_A A = new _ExampleSceneNodePaths_RootNodeName_SecondChild_A();
        public _ExampleSceneNodePaths_RootNodeName_SecondChild_Timer Timer = new _ExampleSceneNodePaths_RootNodeName_SecondChild_Timer();
        public string GetPath() {return "SecondChild";}
        public Node GetNode() { return anyNodeRef.GetTree().CurrentScene.GetNode<Node>(GetPath()); }
    }

    public class _ExampleSceneNodePaths_RootNodeName_SecondChild_Here : IAutomatedNodePath<Node>
    {
        public string GetPath() {return "SecondChild/Here";}
        public Node GetNode() { return anyNodeRef.GetTree().CurrentScene.GetNode<Node>(GetPath()); }
    }

    public class _ExampleSceneNodePaths_RootNodeName_SecondChild_Is : IAutomatedNodePath<Node>
    {
        public string GetPath() {return "SecondChild/Is";}
        public Node GetNode() { return anyNodeRef.GetTree().CurrentScene.GetNode<Node>(GetPath()); }
    }

    public class _ExampleSceneNodePaths_RootNodeName_SecondChild_A : IAutomatedNodePath<Node>
    {
        public string GetPath() {return "SecondChild/A";}
        public Node GetNode() { return anyNodeRef.GetTree().CurrentScene.GetNode<Node>(GetPath()); }
    }

    public class _ExampleSceneNodePaths_RootNodeName_SecondChild_Timer : IAutomatedNodePath<Timer>
    {
        public string GetPath() {return "SecondChild/Timer";}
        public Timer GetNode() { return anyNodeRef.GetTree().CurrentScene.GetNode<Timer>(GetPath()); }
    }

    public class _ExampleSceneNodePaths_RootNodeName_Child3 : IAutomatedNodePath<Node>
    {
        public string GetPath() {return "Child3";}
        public Node GetNode() { return anyNodeRef.GetTree().CurrentScene.GetNode<Node>(GetPath()); }
    }

    public class _ExampleSceneNodePaths_RootNodeName_Player : IAutomatedNodePath<KinematicBody2D>
    {
        public _ExampleSceneNodePaths_RootNodeName_Player_PlayerSprite PlayerSprite = new _ExampleSceneNodePaths_RootNodeName_Player_PlayerSprite();
        public _ExampleSceneNodePaths_RootNodeName_Player_CollisionShape2D CollisionShape2D = new _ExampleSceneNodePaths_RootNodeName_Player_CollisionShape2D();
        public _ExampleSceneNodePaths_RootNodeName_Player_CollisionShape2D2 CollisionShape2D2 = new _ExampleSceneNodePaths_RootNodeName_Player_CollisionShape2D2();
        public string GetPath() {return "Player";}
        public KinematicBody2D GetNode() { return anyNodeRef.GetTree().CurrentScene.GetNode<KinematicBody2D>(GetPath()); }
    }

    public class _ExampleSceneNodePaths_RootNodeName_Player_PlayerSprite : IAutomatedNodePath<Sprite>
    {
        public string GetPath() {return "Player/PlayerSprite";}
        public Sprite GetNode() { return anyNodeRef.GetTree().CurrentScene.GetNode<Sprite>(GetPath()); }
    }

    public class _ExampleSceneNodePaths_RootNodeName_Player_CollisionShape2D : IAutomatedNodePath<CollisionShape2D>
    {
        public string GetPath() {return "Player/CollisionShape2D";}
        public CollisionShape2D GetNode() { return anyNodeRef.GetTree().CurrentScene.GetNode<CollisionShape2D>(GetPath()); }
    }

    public class _ExampleSceneNodePaths_RootNodeName_Player_CollisionShape2D2 : IAutomatedNodePath<CollisionShape2D>
    {
        public string GetPath() {return "Player/CollisionShape2D2";}
        public CollisionShape2D GetNode() { return anyNodeRef.GetTree().CurrentScene.GetNode<CollisionShape2D>(GetPath()); }
    }

    public class _ExampleSceneNodePaths_RootNodeName_UICanvas : IAutomatedNodePath<CanvasLayer>
    {
        public _ExampleSceneNodePaths_RootNodeName_UICanvas_Button1 Button1 = new _ExampleSceneNodePaths_RootNodeName_UICanvas_Button1();
        public _ExampleSceneNodePaths_RootNodeName_UICanvas_Button2 Button2 = new _ExampleSceneNodePaths_RootNodeName_UICanvas_Button2();
        public string GetPath() {return "UICanvas";}
        public CanvasLayer GetNode() { return anyNodeRef.GetTree().CurrentScene.GetNode<CanvasLayer>(GetPath()); }
    }

    public class _ExampleSceneNodePaths_RootNodeName_UICanvas_Button1 : IAutomatedNodePath<Button>
    {
        public string GetPath() {return "UICanvas/Button1";}
        public Button GetNode() { return anyNodeRef.GetTree().CurrentScene.GetNode<Button>(GetPath()); }
    }

    public class _ExampleSceneNodePaths_RootNodeName_UICanvas_Button2 : IAutomatedNodePath<Button>
    {
        public string GetPath() {return "UICanvas/Button2";}
        public Button GetNode() { return anyNodeRef.GetTree().CurrentScene.GetNode<Button>(GetPath()); }
    }

}

