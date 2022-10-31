using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro; 
public class PlayerController : MonoBehaviour
{
    public float Speed = 5f;
    public float JumpSpeed = 8f;
    private float direction = 0f;
    private Rigidbody2D player;
    public bool LookingLeft;

    public Transform GroundCheck;
    public float GroundCheckRadius;
    public LayerMask GroundLayer;
    private bool isTouchingGround;

    private Animator playerAnimation;

    private Vector3 respawnPoint;
    public GameObject FallDetector;
    public TMP_Text ScoreText;
    public HealthBar HealthBar;
    public GameObject TimeTxt;
    public bool IsDead = false;
    public GameObject PlayerBack;
    public SpriteRenderer PlayerSprite;
    public Color InvisableColor;
    public Color NormalColor;
    public bool ShouldBeInvisable;
    public float CurrentTime = 0;
    public float HowLongICanBeInvisable;
    public GameObject HitIcon;
    

    // Start is called before the first frame update
    void Start()
        
    {
        TimeTxt.SetActive(false);
        player = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        respawnPoint = transform.position;
        ScoreText.text = "Score: " + Scoring.totalScore;
    }

    IEnumerator Hearts()
    {
        HitIcon.SetActive(true);
        yield return new WaitForSeconds(2);
        HitIcon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


        CurrentTime += Time.deltaTime;
        if (CurrentTime >= HowLongICanBeInvisable)
        {
            CurrentTime = 0;
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

        isTouchingGround = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, GroundLayer);
        direction = Input.GetAxis("Horizontal");
        Debug.Log(direction);

        if(IsDead == false)
        {
           // TimeTxt.SetActive(false);
        }
        


        if(Health.totalHealth <= 0)

        {

            IsDead = true;
            Debug.Log("Die");
            TimeTxt.SetActive( true );
            PlayerSprite.enabled = false;


        }
        else
        {
            IsDead = false;
        }
        

        if (direction > 0f)

        {
            player.velocity = new Vector2(direction * Speed, player.velocity.y);
            transform.localScale = new Vector2(-0.09781352f, 0.09781352f);
            LookingLeft = false;
        }

        else if (direction < 0f)
        {
            player.velocity = new Vector2(direction * Speed, player.velocity.y);
            transform.localScale = new Vector2(0.09781352f, 0.09781352f);
            LookingLeft = true;
        }

        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            player.velocity = new Vector2(player.velocity.x, JumpSpeed);
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
            Scoring.totalScore = 0;
        }
        else if (collision.tag == "Main_Menu")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + -3);
            respawnPoint = transform.position;
            Scoring.totalScore = 0;
        }

        else if(collision.tag == "Point")
        {
            Scoring.totalScore += 1;
            ScoreText.text = "Score: " + Scoring.totalScore;
            collision.gameObject.SetActive(false);
        }
        else if(collision.tag == "Death_Point")
        {
            StartCoroutine(Hearts());
            HealthBar.Damage(0.2f);
        }





    }


    





}


