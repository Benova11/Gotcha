using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Vector2Int startCoordinate;
    public Vector2Int StartCoordinate { get { return startCoordinate; } }

    [SerializeField] Vector2Int destanationCoordinate;
    public Vector2Int DestanationCoordinate { get { return destanationCoordinate; } }

    Node startNode;
    Node destinationNode;
    Node currentSearchNode;

    Dictionary<Vector2Int, Node> reached = new Dictionary<Vector2Int, Node>();
    Queue<Node> frontier = new Queue<Node>();

    Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };
    private Vector2Int tmpDirection;

    GridManager gridManager;
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        if(gridManager != null)
        {
            grid = gridManager.Grid;
            startNode = grid[startCoordinate];
            destinationNode = grid[destanationCoordinate];
        }
    }

    void Start()
    {
        GetNewPath();
    }

    public List<Node> GetNewPath()
    {
        return GetNewPath(startCoordinate);
    }

    public List<Node> GetNewPath(Vector2Int coordinates)
    {
        gridManager.resetNodes();
        BreadthFirstSearch(coordinates);
        return CreatePath();
    }

    void ExploreNeighbors()
    {
        List<Node> neighbors = new List<Node>();
        ShuffleDirections();
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighborCoords = currentSearchNode.coordinates + direction;

            if (grid.ContainsKey(neighborCoords))
            {
                neighbors.Add(grid[neighborCoords]);
            }
        }

        foreach (Node neighbor in neighbors)
        {
            if (!reached.ContainsKey(neighbor.coordinates) && neighbor.isPassable)
            {
                neighbor.connectedTo = currentSearchNode;
                frontier.Enqueue(neighbor);
                reached.Add(neighbor.coordinates, neighbor);
            }
        }
    }

public void ShuffleDirections()
{
    for (int i = 0; i < directions.Length; i++)
    {
        int rnd = UnityEngine.Random.Range(0, directions.Length);
        tmpDirection = directions[rnd];
        directions[rnd] = directions[i];
        directions[i] = tmpDirection;
    }
}

void BreadthFirstSearch(Vector2Int coordinates)
    {
        startNode.isPassable = true;
        destinationNode.isPassable = true;

        frontier.Clear();
        reached.Clear();

        bool isRunning = true;

        frontier.Enqueue(grid[coordinates]);
        reached.Add(coordinates, grid[coordinates]);

        while(frontier.Count > 0 && isRunning)
        {
            currentSearchNode = frontier.Dequeue();
            currentSearchNode.isExplored = true;
            ExploreNeighbors();
            if(currentSearchNode.coordinates == destanationCoordinate)
            {
                isRunning = false;
            }
        }
    }

    List<Node> CreatePath()
    {
        List<Node> path = new List<Node>();
        Node currentNode = destinationNode;

        path.Add(currentNode);
        currentNode.isPath = true;

        while(currentNode.connectedTo != null)
        {
            currentNode = currentNode.connectedTo;
            path.Add(currentNode);
            currentNode.isPath = true;
        }

        path.Reverse();
        return path;
    }

    public bool WillBlockPath(Vector2Int coordinates)
    {
        if (grid.ContainsKey(coordinates))
        {
            bool previousState = grid[coordinates].isPassable;

            grid[coordinates].isPassable = false;
            List<Node> newPath = GetNewPath();
            grid[coordinates].isPassable = previousState;

            if(newPath.Count <= 1)
            {
                GetNewPath();
                return true;
            }
        }
        return false;
    }

    public void NotifyReceivers()
    {
        BroadcastMessage("CalculatePath",false, SendMessageOptions.DontRequireReceiver);
    }
}
