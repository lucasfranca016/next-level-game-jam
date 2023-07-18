using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{

    public UnityEvent GameOverEvent;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if((collision.transform.tag == "EnemyR") || (collision.transform.tag == "EnemyB") || (collision.transform.tag == "Boss"))
        {
            TakeDamage();
        }

        if (collision.transform.tag == "Death")
        {
            GameOverEvent.Invoke();
            gameObject.SetActive(false);
        }

        if (collision.transform.tag == "Heal")
        {
            HealthManager.health = 3;
            Destroy(collision.gameObject);
        }
    }

    public void TakeDamage()
    {
        HealthManager.health--;
        if (HealthManager.health <= 0)
        {
            GameOverEvent.Invoke();
            //AudioManager.instance.Play("GameOver");
            gameObject.SetActive(false);
        }
        else
        {
            StartCoroutine(GetHurt());
        }
    }

    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(7, 6);
        //GetComponent<Animator>().SetLayerWeight(1, 1);
        yield return new WaitForSeconds(3);
        //GetComponent<Animator>().SetLayerWeight(1, 1); faz piscar
        Physics2D.IgnoreLayerCollision(7, 6, false);
    }
}
