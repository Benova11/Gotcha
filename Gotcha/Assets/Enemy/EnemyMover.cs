using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();

    void Start()
    {
        PrintWaypointName();
    }

    void Update()
    {
        
    }

    void PrintWaypointName()
    {
        foreach (Waypoint wp in path)
        {
            Debug.Log(wp.name);
        }
    }
}
