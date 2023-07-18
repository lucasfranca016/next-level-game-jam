using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;
    public string element;
    public SpriteRenderer spriteRenderer;
    private string currentElement;
    public BulletScriptObj Bullet1, Bullet2;
    private BulletScriptObj currentBullet;
    public Rigidbody2D rb;

    void Start()
    {
        DefiningElement();

        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        if (hitInfo.tag == "Bullet")
        {
            Destroy(hitInfo.gameObject);
            Destroy(gameObject);
        }
        if ((hitInfo.tag == "ShieldB") || (hitInfo.tag == "ShieldR"))
        {
            CheckShieldElement(hitInfo);
        }
        if ((hitInfo.tag == "EnemyB") || (hitInfo.tag == "EnemyR"))
        {
            CheckEnemyElement(hitInfo);
        }
        if ((hitInfo.tag == "Boss"))
        {
            BossLife BossLife = hitInfo.GetComponent<BossLife>();
            BossLife.TakeDamage(damage);
            Destroy(gameObject);
        }
        else
        {
            Bullet bullet = hitInfo.GetComponent<Bullet>();
            if (bullet == null)
            {
                Destroy(gameObject);
            }
        }
    }

    void CheckShieldElement(Collider2D hitInfo)
    {
        if (((hitInfo.tag == "ShieldB") && (element == "Fire")) || ((hitInfo.tag == "ShieldR") && (element == "Lighting")))
        {
            Shield Shield = hitInfo.GetComponent<Shield>();
            Shield.TakeDamage(damage);
            Destroy(gameObject);
        }
        else
        {
            Bullet bullet = hitInfo.GetComponent<Bullet>();
            if (bullet == null)
            {
                Destroy(gameObject);
            }
        }
    } 

    void CheckEnemyElement(Collider2D hitInfo)
    {
        if (((hitInfo.tag == "EnemyB") && (element == "Fire")) || ((hitInfo.tag == "EnemyR") && (element == "Lighting")))
        {
            EnemyTest EnemyTest = hitInfo.GetComponent<EnemyTest>();
            EnemyTest.TakeDamage(damage);
            Destroy(gameObject);
        }
        else
        {
            Bullet bullet = hitInfo.GetComponent<Bullet>();
            if (bullet == null)
            {
                Destroy(gameObject);
            }
        }
    }

    void DefiningElement()
    {
        currentElement = GameObject.Find("Manager").GetComponent<ElementManager>().element;

        if (currentElement=="fire")
        {
            currentBullet = Bullet1;
            spriteRenderer.color = Color.red;
        }

        if (currentElement == "ice")
        {
            currentBullet = Bullet2;
        }

        speed = currentBullet.speed;
        damage = currentBullet.damage;
        element = currentBullet.element;
        spriteRenderer.sprite = currentBullet.artwork;
    }
}
