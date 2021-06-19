using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] float waitTime = 1f;;

    void Start()
    {
        StartCoroutine(FollowPath());
    }

    void Update()
    {

    }

    IEnumerator FollowPath()
    {
        foreach (Waypoint wp in path)
        {
            //Debug.Log(wp.name);
            transform.SetPositionAndRotation(wp.transform.position,Quaternion.identity);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
