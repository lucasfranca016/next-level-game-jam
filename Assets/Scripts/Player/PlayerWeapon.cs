using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public Transform firePoint, firePoint2;
    public GameObject bulletPrefab;
    private PlayerMovement mov;
    private bool Cooldown;
    public float timeCounter, cooldownTime = 1;

    void FixedUpdate()
    {
        mov = GetComponent<PlayerMovement>();

        if (Cooldown == true)
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
        if (Cooldown == false)
        {
            if (mov.isCrouch == false)
            {
                Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            }
            else
            {
                Instantiate(bulletPrefab, firePoint2.position, firePoint.rotation);
            }
            Cooldown = true;
        }

    }
}
