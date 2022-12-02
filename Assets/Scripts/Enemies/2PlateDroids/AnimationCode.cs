using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCode : MonoBehaviour
{
    public GameObject Enemy;
    public AudioSource AudioSrc;
    public AudioClip EnemyDeathAudio;

    public void DeathSound()
    {
        AudioSrc.PlayOneShot(EnemyDeathAudio);
    }
    public void Delete()
    {
        Destroy(Enemy);
    }
}
