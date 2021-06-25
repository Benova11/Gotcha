using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Node
{
    public Node connectedTo;
    public Vector2Int coordinates;
    public bool isPassable;
    public bool isExplored;
    public bool isPath;

    public Node(Vector2Int coordinates, bool isPassable)
    {
        this.coordinates = coordinates;
        this.isPassable = isPassable;
    }
}
