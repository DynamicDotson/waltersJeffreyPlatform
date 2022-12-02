using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoPlayerScript : MonoBehaviour
{

    public VideoPlayer VP;
    // Start is called before the first frame update
    void Start()
    {
        VP.loopPointReached += MainMenu;
    }

    // Update is called once per frame
    public void MainMenu(VideoPlayer vp)
    {
        VP.loopPointReached -= MainMenu;

        Debug.Log("Next Scene");
        SceneManager.LoadScene(1);

    }
}
