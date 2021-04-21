using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;

    float distanceToTarget = Mathf.Infinity;
    NavMeshAgent navMeshAgent;
    bool isProvoked = false;
    EnemyHealth health;
    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemeyDie();
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (!health.IsDead())
        {
            if (isProvoked)
            {
                EngageTarget();
            }
            else if (distanceToTarget <= chaseRange)
            {
                isProvoked = true;

            }
        }
    }

    public void EnemeyDie()
    {
        if (health.IsDead())
        {
            
            navMeshAgent.enabled = false;
        }
    }

    public void OnDamage()
    {
        isProvoked = true;
    }

    private void EngageTarget()
    {
        FaceTarget();
        if(distanceToTarget > navMeshAgent.stoppingDistance+1)
        {
            ChaseTarget();
        }
        if(distanceToTarget <= navMeshAgent.stoppingDistance+1)
        {
            AttackTarget();
        }
        
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetTrigger("attack");
        
    }

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,chaseRange);
    }
    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }
}
