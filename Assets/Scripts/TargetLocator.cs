using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    public Transform weapon;
    public float range = 15f;

    public ParticleSystem arrowParticles;

    private Transform enemy;

    void Update()
    {
        FindClosestTarget();
        TargetEnemy();
    }

    private void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach(Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if(targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }

        enemy = closestTarget;
    }

    private void TargetEnemy()
    {
        float targetDistance = Vector3.Distance(transform.position, enemy.position);

        if(targetDistance < range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }

        weapon.LookAt(enemy);
    }

    private void Attack(bool isActive)
    {
        var emissionModule = arrowParticles.emission;
        emissionModule.enabled = isActive;
    }
}
