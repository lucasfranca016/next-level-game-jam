using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float speed;
    public SpriteRenderer spriteRenderer;
    public BulletScriptObj Bullet;
    public Rigidbody2D rb;

    void Start()
    {
        DefiningElement();

        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.gameObject.layer == 7)
        {
            hitInfo.GetComponent<PlayerCollision>().TakeDamage();
            Destroy(gameObject);
        }
    }    

    void DefiningElement()
    {
        speed = Bullet.speed;
        spriteRenderer.sprite = Bullet.artwork;
    }
}
