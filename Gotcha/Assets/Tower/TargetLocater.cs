using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocater : MonoBehaviour
{

    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectilleParticles;
    [SerializeField] float range = 15f;
    Transform target;

    private void OnEnable()
    {
        StartCoroutine(FindClosestTarget());
    }

    void Update()
    {
        if (target)
        {
            AimWeapon();
        }
    }

    void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.transform.position);
        Attack(targetDistance <= range);
        weapon.LookAt(target);
    }

    IEnumerator FindClosestTarget()
    {
        while (true)
        {
            Enemy[] enemies = FindObjectsOfType<Enemy>();
            Transform closestTarget = null;
            float maxDistance = Mathf.Infinity;
            foreach (Enemy enemy in enemies)
            {
                float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
                if (targetDistance < maxDistance)
                {
                    closestTarget = enemy.transform;
                    maxDistance = targetDistance;
                }
            }
            target = closestTarget;
            yield return new WaitForSeconds(1);
        }
    }

    void Attack(bool isInRange)
    {
        var emissionModule = projectilleParticles.emission;
        emissionModule.enabled = isInRange;
    }
}
