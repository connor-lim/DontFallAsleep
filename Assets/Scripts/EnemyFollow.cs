using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;

    [SerializeField] LayerMask groundLayer, playerLayer;

    public Animator animator;
    BoxCollider boxCollider;

    Vector3 destPoint;
    bool walkPointSet;
    [SerializeField] float range;

    [SerializeField] float sightRange, attackRange;
    bool playerInSight, playerInRange;

    public float speed;
    public float attack_speed;

    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        animator = GetComponent<Animator>();
        boxCollider = GetComponentInChildren<BoxCollider>();

    }

    void Update()
    {
        playerInSight = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        playerInRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);
        if (!playerInSight && !playerInRange) 
        {
            Patrol();
        }
        if (playerInSight && !playerInRange) 
        {
            Chase();
        }
        if (playerInSight && playerInRange)
        {
            Attack();
        }
    }

    void Chase()
    {
        enemy.speed = attack_speed;
        animator.SetTrigger("Chase");
        enemy.SetDestination(player.transform.position);
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        enemy.SetDestination(transform.position);
    }

    void Patrol()
    {
        animator.SetTrigger("Patrol");
        if (!walkPointSet)
        {
            SearchForDest();
        }
        if (walkPointSet) 
        {
            enemy.SetDestination(destPoint);
        }
        if (Vector3.Distance(transform.position, destPoint) < 10)
        {
            walkPointSet = false;
        }
    }

    void SearchForDest()
    {
        float z = Random.Range(-range, range);
        float x = Random.Range(-range, range);

        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if (Physics.Raycast(destPoint, Vector3.down, groundLayer))
        {
            walkPointSet = true;
        }
    }

    void EnableAttack()
    {
        boxCollider.enabled = true;
    }

    void DisableAttack()
    {
        boxCollider.enabled = false;
    }


}
