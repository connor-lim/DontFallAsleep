using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FinalEnemyFollow : MonoBehaviour
{
    public NavMeshAgent enemy;
    Transform player;

    public AudioSource fireball;

    [SerializeField] LayerMask groundLayer, playerLayer;

    //public Animator animator;
    BoxCollider boxCollider;

    Vector3 destPoint;
    bool walkPointSet;
    [SerializeField] float range;

    [SerializeField] float sightRange, attackRange;
    bool playerInSight, playerInRange;

    public float speed;
    public float attack_speed;

    bool alreadyAttacked;
    public float timeBetweenAttacks;
    public GameObject projectile;

    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        //animator = GetComponent<Animator>();
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
        //animator.SetTrigger("Chase");
        enemy.SetDestination(player.transform.position);
    }

    void Attack()
    {
        //animator.SetTrigger("Attack");
        transform.LookAt(player);
        enemy.SetDestination(transform.position);

        if (!alreadyAttacked)
        {
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 100f, ForceMode.Impulse);
            rb.AddForce(transform.up * 4f, ForceMode.Impulse);

            fireball.Play();

            alreadyAttacked = true;

            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    void Patrol()
    {
        //animator.SetTrigger("Patrol");
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
