using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float attackRefreshrate = 1.5f;
    private float attackTimer;

    private AggroDetection aggroDetection;
    private Health healthTarget;

    

    private void Awake()
    {
        aggroDetection = GetComponent<AggroDetection>();
        aggroDetection.OnAggro += AggroDetection_OnAggro;
    }

    private void AggroDetection_OnAggro(Transform target)
    {
        Health health = target.GetComponent<Health>();
        if(health != null)
        {
            healthTarget = health;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(healthTarget != null)
        {
            attackTimer += Time.deltaTime;
            if (CanAttack())
            {
                Attack();
            }
        } 
    }

    private bool CanAttack()
    {
        return attackTimer >= attackRefreshrate;
    }

    private void Attack()
    {
        attackTimer = 0;
        healthTarget.TakeDamage(1);
    }
}
