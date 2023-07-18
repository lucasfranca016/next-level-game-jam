using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLayer : MonoBehaviour
{
    private PlayerMovement player;
    private GameObject obj;
    private MovingPlatform script;
    private Vector2 vel;


    void Start()
    {
        obj = this.gameObject;
    }

    void FixedUpdate()
    {
        script = transform.parent.gameObject.GetComponent<MovingPlatform>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        player = collision.gameObject.GetComponent<PlayerMovement>();
        if (player != null)
        {
            player.UpdateVelocity(script.newVelocity);
            obj.SetActive(false);
        }
    }
}
