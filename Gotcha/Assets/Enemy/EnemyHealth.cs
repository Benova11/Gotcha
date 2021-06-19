using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    int currentHitpoints = 0;

    void Start()
    {
        currentHitpoints = maxHitPoints;
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("collision");
        ProcessHit();
    }

    void ProcessHit()
    {
        currentHitpoints --;
        if (currentHitpoints <= 0 )
        {
            Destroy(gameObject);
        }
    }
}
