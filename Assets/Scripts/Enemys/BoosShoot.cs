using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab, bulletPrefab2;
    private bool Cooldown = false;
    private float timeCounter, cooldownTime = 5;
    private string lastBullet = "light"; 

    void FixedUpdate()
    {
        if (Cooldown == false)
        {
            Shoot();
        }
        else
        {
            timeCounter += Time.deltaTime;
            if (timeCounter > cooldownTime)
            {
                Cooldown = false;
                timeCounter = 0;
            }
        }
    }

    public void Shoot()
    {
        if (lastBullet == "light")
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Cooldown = true;
            lastBullet = "fire";
        }
        else
        {
            Instantiate(bulletPrefab2, firePoint.position, firePoint.rotation);
            Cooldown = true;
            lastBullet = "light";
        }
    }
}
