using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ChocolateStand : MonoBehaviour
{

    public float timeToTogglePlatform = 2;
    public float currentTime = 0;
    public bool enable = true;
    public bool PlayerHasHitChocolateStand;
    public GameObject Player;
    public Color InvisableColor;
    public Color NormalColor;
    // Start is called before the first frame update
    void Start()
    {
        enable = true;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= timeToTogglePlatform)
        {
            currentTime = 0;
            PlayerHasHitChocolateStand = false;
        }

        if(PlayerHasHitChocolateStand == true)
        {
            gameObject.GetComponent<SpriteRenderer>().color = InvisableColor;

        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = NormalColor;

        }
    }
   

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            PlayerHasHitChocolateStand = true;
            Player = collision.gameObject;
            Player.GetComponent<PlayerController>().ShouldBeInvisable = true;
        }
    }
}
