using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFallow : MonoBehaviour
{
    public GameObject Player;
    public float Speed;
    public PlayerController StopFallowing;

    private float distance;
    //Start is called before the first frame update

    void Start()
    {
        StopFallowing = FindObjectOfType<PlayerController>();
       
    }

    // Update is called once per frame

    void Update()
    {


        if(Player == null)
        {
            return;
        }

        //distance = Vector2.Distance(transform.position, player.transform.position);
        //Vector2 direction = player.transform.position - transform.position;

        if(!StopFallowing.ShouldBeInvisable)    
        {
            distance = Vector2.Distance(transform.position, Player.transform.position);
            Vector2 direction = Player.transform.position - transform.position;
        }





        if (distance < 8)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, Speed * Time.deltaTime);
        }


    }
}

