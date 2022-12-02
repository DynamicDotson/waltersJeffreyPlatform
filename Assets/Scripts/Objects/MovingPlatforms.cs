using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    public float speed;
    public int startingPoint;
    public Transform[] points;
    public bool PlayerDrivon;
    public bool PlayerIsOn;

    private int i;


    void Start()
    {
        transform.position = points[startingPoint].position;
    }

    void Update()
    {
        if (PlayerDrivon == false || (PlayerDrivon == true && PlayerIsOn == true))
        {
            if (Vector2.Distance(transform.position, points[i].position) < 0.2f)
            {

                i++;
                if (i == points.Length)
                {
                    i = 0;
                }

            }

            transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        }
    }

       

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
        if (collision.transform.tag == "Player")
        {
            PlayerIsOn = true;
        } 

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
        if (collision.transform.tag == "Player")
        {
            PlayerIsOn = false;
        }
    }
}
