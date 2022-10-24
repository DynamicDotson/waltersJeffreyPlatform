using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro; 
public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 8f;
    private float direction = 0f;
    private Rigidbody2D player;
    public bool LookingLeft;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;

    private Animator playerAnimation;

    private Vector3 respawnPoint;
    public GameObject fallDetector;
    public TMP_Text scoreText;
    public HealthBar healthBar;
    public GameObject TimeTxt;
    public bool isDead = false;
    public GameObject playerBack;
    public SpriteRenderer playerSprite;
    public Color InvisableColor;
    public Color NormalColor;
    public bool ShouldBeInvisable;
    public float currentTime = 0;
    public float HowLongICanBeInvisable;


    // Start is called before the first frame update
    void Start()
        
    {
        TimeTxt.SetActive(false);
        player = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        respawnPoint = transform.position;
        scoreText.text = "Score: " + Scoring.totalScore;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= HowLongICanBeInvisable)
        {
            currentTime = 0;
            ShouldBeInvisable = false;
        }


        if (ShouldBeInvisable == true)
        {
            gameObject.GetComponent<SpriteRenderer>().color = InvisableColor;


        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = NormalColor;

        }

        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        direction = Input.GetAxis("Horizontal");
        Debug.Log(direction);

        if(isDead == false)
        {
           // TimeTxt.SetActive(false);
        }
        


        if(Health.totalHealth <= 0)

        {

            isDead = true;
            Debug.Log("Die");
            TimeTxt.SetActive( true );
            playerSprite.enabled = false;


        }
        else
        {
            isDead = false;
        }
        

        if (direction > 0f)

        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            transform.localScale = new Vector2(-0.09781352f, 0.09781352f);
            LookingLeft = false;
        }

        else if (direction < 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            transform.localScale = new Vector2(0.09781352f, 0.09781352f);
            LookingLeft = true;
        }

        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        }

        playerAnimation.SetFloat("Speed", Mathf.Abs(player.velocity.x));
        playerAnimation.SetBool("OnGround", isTouchingGround);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "FallDetector")
        {
            transform.position = respawnPoint;
        }

        else if(collision.tag == "Checkpoint")
        {
            respawnPoint = transform.position;
        }
        else if(collision.tag == "Next_Level")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            respawnPoint = transform.position;
        }
        else if (collision.tag == "Previous_Level")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            respawnPoint = transform.position;
        }
        else if (collision.tag == "Finish_level")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            respawnPoint = transform.position;
        }
        else if (collision.tag == "Return_Home")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + -2);
            respawnPoint = transform.position;
        }

        else if(collision.tag == "Point")
        {
            Scoring.totalScore += 1;
            scoreText.text = "Score: " + Scoring.totalScore;
            collision.gameObject.SetActive(false);
        }
        else if(collision.tag == "Death_Point")
        {
            healthBar.Damage(0.2f);
        }



    }


    





}


