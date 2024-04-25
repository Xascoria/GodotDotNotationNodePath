using Godot;
using System;

public class _ExampleSceneNodePaths
{
    public _ExampleSceneNodePaths_RootNodeName RootNodeName = new _ExampleSceneNodePaths_RootNodeName();
    public class _ExampleSceneNodePaths_RootNodeName : IAutomatedNodePath
    {
        public _ExampleSceneNodePaths_RootNodeName_FirstChild FirstChild = new _ExampleSceneNodePaths_RootNodeName_FirstChild();
        public _ExampleSceneNodePaths_RootNodeName_SecondChild SecondChild = new _ExampleSceneNodePaths_RootNodeName_SecondChild();
        public _ExampleSceneNodePaths_RootNodeName_Child3 Child3 = new _ExampleSceneNodePaths_RootNodeName_Child3();
        public _ExampleSceneNodePaths_RootNodeName_Player Player = new _ExampleSceneNodePaths_RootNodeName_Player();
        public _ExampleSceneNodePaths_RootNodeName_UICanvas UICanvas = new _ExampleSceneNodePaths_RootNodeName_UICanvas();
        public string GetPath() { throw new Exception("GetPath() called on Root disallowed"); }
        public Node GetNode(Node rootNode) { return rootNode; }
    }

    public class _ExampleSceneNodePaths_RootNodeName_FirstChild : IAutomatedNodePath
    {
        public _ExampleSceneNodePaths_RootNodeName_FirstChild_Sprite Sprite = new _ExampleSceneNodePaths_RootNodeName_FirstChild_Sprite();
        public _ExampleSceneNodePaths_RootNodeName_FirstChild_Sprite2 Sprite2 = new _ExampleSceneNodePaths_RootNodeName_FirstChild_Sprite2();
        public string GetPath() {return "FirstChild";}
        public Node GetNode(Node rootNode) { return rootNode.GetNode<FirstChild>(GetPath()); }
    }

    public class _ExampleSceneNodePaths_RootNodeName_FirstChild_Sprite : IAutomatedNodePath
    {
        public string GetPath() {return "FirstChild/Sprite";}
        public Node GetNode(Node rootNode) { return rootNode.GetNode<Sprite>(GetPath()); }
    }

    public class _ExampleSceneNodePaths_RootNodeName_FirstChild_Sprite2 : IAutomatedNodePath
    {
        public string GetPath() {return "FirstChild/Sprite2";}
        public Node GetNode(Node rootNode) { return rootNode.GetNode<Sprite>(GetPath()); }
    }

    public class _ExampleSceneNodePaths_RootNodeName_SecondChild : IAutomatedNodePath
    {
        public _ExampleSceneNodePaths_RootNodeName_SecondChild_Here Here = new _ExampleSceneNodePaths_RootNodeName_SecondChild_Here();
        public _ExampleSceneNodePaths_RootNodeName_SecondChild_Is Is = new _ExampleSceneNodePaths_RootNodeName_SecondChild_Is();
        public _ExampleSceneNodePaths_RootNodeName_SecondChild_A A = new _ExampleSceneNodePaths_RootNodeName_SecondChild_A();
        public _ExampleSceneNodePaths_RootNodeName_SecondChild_Timer Timer = new _ExampleSceneNodePaths_RootNodeName_SecondChild_Timer();
        public string GetPath() {return "SecondChild";}
        public Node GetNode(Node rootNode) { return rootNode.GetNode<Node>(GetPath()); }
    }

    public class _ExampleSceneNodePaths_RootNodeName_SecondChild_Here : IAutomatedNodePath
    {
        public string GetPath() {return "SecondChild/Here";}
        public Node GetNode(Node rootNode) { return rootNode.GetNode<Node>(GetPath()); }
    }

    public class _ExampleSceneNodePaths_RootNodeName_SecondChild_Is : IAutomatedNodePath
    {
        public string GetPath() {return "SecondChild/Is";}
        public Node GetNode(Node rootNode) { return rootNode.GetNode<Node>(GetPath()); }
    }

    public class _ExampleSceneNodePaths_RootNodeName_SecondChild_A : IAutomatedNodePath
    {
        public string GetPath() {return "SecondChild/A";}
        public Node GetNode(Node rootNode) { return rootNode.GetNode<Node>(GetPath()); }
    }

    public class _ExampleSceneNodePaths_RootNodeName_SecondChild_Timer : IAutomatedNodePath
    {
        public string GetPath() {return "SecondChild/Timer";}
        public Node GetNode(Node rootNode) { return rootNode.GetNode<Timer>(GetPath()); }
    }

    public class _ExampleSceneNodePaths_RootNodeName_Child3 : IAutomatedNodePath
    {
        public string GetPath() {return "Child3";}
        public Node GetNode(Node rootNode) { return rootNode.GetNode<Node>(GetPath()); }
    }

    public class _ExampleSceneNodePaths_RootNodeName_Player : IAutomatedNodePath
    {
        public _ExampleSceneNodePaths_RootNodeName_Player_PlayerSprite PlayerSprite = new _ExampleSceneNodePaths_RootNodeName_Player_PlayerSprite();
        public _ExampleSceneNodePaths_RootNodeName_Player_CollisionShape2D CollisionShape2D = new _ExampleSceneNodePaths_RootNodeName_Player_CollisionShape2D();
        public _ExampleSceneNodePaths_RootNodeName_Player_CollisionShape2D2 CollisionShape2D2 = new _ExampleSceneNodePaths_RootNodeName_Player_CollisionShape2D2();
        public string GetPath() {return "Player";}
        public Node GetNode(Node rootNode) { return rootNode.GetNode<KinematicBody2D>(GetPath()); }
    }

    public class _ExampleSceneNodePaths_RootNodeName_Player_PlayerSprite : IAutomatedNodePath
    {
        public string GetPath() {return "Player/PlayerSprite";}
        public Node GetNode(Node rootNode) { return rootNode.GetNode<Sprite>(GetPath()); }
    }

    public class _ExampleSceneNodePaths_RootNodeName_Player_CollisionShape2D : IAutomatedNodePath
    {
        public string GetPath() {return "Player/CollisionShape2D";}
        public Node GetNode(Node rootNode) { return rootNode.GetNode<CollisionShape2D>(GetPath()); }
    }

    public class _ExampleSceneNodePaths_RootNodeName_Player_CollisionShape2D2 : IAutomatedNodePath
    {
        public string GetPath() {return "Player/CollisionShape2D2";}
        public Node GetNode(Node rootNode) { return rootNode.GetNode<CollisionShape2D>(GetPath()); }
    }

    public class _ExampleSceneNodePaths_RootNodeName_UICanvas : IAutomatedNodePath
    {
        public _ExampleSceneNodePaths_RootNodeName_UICanvas_Button1 Button1 = new _ExampleSceneNodePaths_RootNodeName_UICanvas_Button1();
        public _ExampleSceneNodePaths_RootNodeName_UICanvas_Button2 Button2 = new _ExampleSceneNodePaths_RootNodeName_UICanvas_Button2();
        public string GetPath() {return "UICanvas";}
        public Node GetNode(Node rootNode) { return rootNode.GetNode<CanvasLayer>(GetPath()); }
    }

    public class _ExampleSceneNodePaths_RootNodeName_UICanvas_Button1 : IAutomatedNodePath
    {
        public string GetPath() {return "UICanvas/Button1";}
        public Node GetNode(Node rootNode) { return rootNode.GetNode<Button>(GetPath()); }
    }

    public class _ExampleSceneNodePaths_RootNodeName_UICanvas_Button2 : IAutomatedNodePath
    {
        public string GetPath() {return "UICanvas/Button2";}
        public Node GetNode(Node rootNode) { return rootNode.GetNode<Button>(GetPath()); }
    }

}

