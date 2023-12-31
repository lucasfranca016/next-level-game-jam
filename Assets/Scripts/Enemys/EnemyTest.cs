using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    public int health = 100;

    public GameObject deathEffect;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            transform.parent.gameObject.GetComponent<EnemyGenerator>().CooldownActive();
            Die();
        }
    }

    public void Die()
    {
        Instantiate(deathEffect,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
