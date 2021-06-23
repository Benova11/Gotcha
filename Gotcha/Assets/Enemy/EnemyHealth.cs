using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;

    [Tooltip("Add amount to maxHitPoints when enemy dies.")]
    [SerializeField] int difficultyRamp = 1;

    int currentHitpoints = 0;

    Enemy enemy;

    void OnEnable()
    {
        currentHitpoints = maxHitPoints;
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnParticleCollision(GameObject other)
    {
        //Debug.Log("collision");
        ProcessHit();
    }

    void ProcessHit()
    {
        currentHitpoints --;
        if (currentHitpoints <= 0 )
        {
            gameObject.SetActive(false);
            maxHitPoints += difficultyRamp;
            enemy.RewardGold();
        }
    }
}
