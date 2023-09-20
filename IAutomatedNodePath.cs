using System;
using Godot;

public interface IAutomatedNodePath
{
    string GetPath();
    Node GetNode(Node rootNode);
}