using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRepeats : MonoBehaviour
{
    public float scrollSpeed = 3;

    // background width in pixels / pixels per Unit
    public const float ScrollWidth = 8;

    // Update is called once per frame
    void Update()
    {
        // Getting the current background position
        Vector2 pos = transform.position;

        // Moving the object the the left
        pos.x -= scrollSpeed * Time.deltaTime;

        // Check if object is completely off the sreen
        if (transform.position.x < -ScrollWidth)
        {
            Offscreen(ref pos);
        }

        // Updating the position to the new place
        transform.position = pos;
    }

    public virtual void Offscreen(ref Vector2 pos)
    {
        pos.x += 2 * ScrollWidth;
    }

}
