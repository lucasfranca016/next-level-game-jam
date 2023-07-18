using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public float Cooldown;

    private bool isCd;

    public bool turned=false;

    private float cdCounter;

    private Vector3 rot;

    public Transform Player;

    public GameObject enemyPrefab;

    void Start()
    {
        rot = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCd == false)
        {
            CheckDistance();
        }
        else
        {
            CdCounter();
        }
    }

    private void CheckDistance()
    {
        if (Vector2.Distance(Player.position,transform.position)<=12)
        {
            if(transform.childCount == 0)
            {
                if(turned == false)
                {
                    Instantiate(enemyPrefab, transform.position, Quaternion.identity, transform);
                }
                else
                {
                    Instantiate(enemyPrefab, transform.position, Quaternion.Euler(new Vector3(rot.x, rot.y + 180, rot.z)), transform);
                }
            }
        }

        //Debug.Log(Vector2.Distance(Player.position, transform.position));
    }

    public void CooldownActive()
    {
        isCd = true;
    }

    private void CdCounter()
    {
        cdCounter += Time.deltaTime;
        if (cdCounter >= Cooldown)
        {
            isCd = false;
            cdCounter = 0;
        }
    }
}
