using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioSource zombie;
    public GameObject bottlecap;
    public float health = 100f;
    public float damage = 10f;

    void Start()
    {
        zombie.Play();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
        Instantiate(bottlecap, transform.position, Quaternion.identity);
    }
}
