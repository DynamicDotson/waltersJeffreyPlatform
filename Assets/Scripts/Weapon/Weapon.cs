using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public PlayerController Controller;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
      var bullet =  Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        if(Controller.LookingLeft == true)
        {
            bullet.GetComponent<Bullet>().speed *= -1;
 
        }
    }
}
