using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFallow : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public PlayerController stopFallowing;

    private float distance;
    //Start is called before the first frame update

    void Start()
    {
        stopFallowing = FindObjectOfType<PlayerController>();
       
    }

    // Update is called once per frame

    void Update()
    {


        if(player == null)
        {
            return;
        }

        //distance = Vector2.Distance(transform.position, player.transform.position);
        //Vector2 direction = player.transform.position - transform.position;

        if(!stopFallowing.ShouldBeInvisable)    
        {
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;
        }





        if (distance < 8)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }


    }
}

