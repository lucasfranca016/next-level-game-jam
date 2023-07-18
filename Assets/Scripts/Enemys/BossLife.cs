using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossLife : MonoBehaviour
{
    public int health = 250;

    public GameObject deathEffect;

    public UnityEvent EndGame;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        EndGame.Invoke();

    }
}
