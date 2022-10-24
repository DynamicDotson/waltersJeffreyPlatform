using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn = false;

    public TMP_Text TimerTxt;
    public GameObject restartButton;
    public SpriteRenderer playerSprite;
    void Start()
    {
        TimerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerOn)
        {
            if(TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                UpdateTimer(TimeLeft);
            }
            else
            {
                Debug.Log("Time is UP!");
                TimeLeft = 0;
                TimerOn = false;
                restartButton.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
    void UpdateTimer(float currentTime)
    {
        

        
        var timeLeft = TimeSpan.FromSeconds(TimeLeft);
        TimerTxt.text = timeLeft.Minutes.ToString() + ":" + timeLeft.Seconds.ToString();

    }
    public void RestartGame()

    {
        playerSprite.enabled = true;
        Health.totalHealth = 1f;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);

        

    }

    
}
