using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject BulletPrefab;
    public PlayerController Controller;
    public AudioSource AS;
    public AudioClip ShootingClip;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        AS.PlayOneShot(ShootingClip);
        //AS.Play(ShootingClip);
        
      var bullet =  Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        if(Controller.LookingLeft == true)
        {
            bullet.GetComponent<Bullet>().Speed *= -1;
 
        }
    }
}
