using System;
using Godot;

public interface IAutomatedNodePath<T>
{
    string GetPath();
    T GetNode();
}
