using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCode : MonoBehaviour
{
    public GameObject Enemy;
    public void Delete()
    {
        Destroy(Enemy);
    }
}
