using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float offset;
    public float offsetSmoothing;
    private Vector3 playerPosition;
    private float yoffset;
    public float CameraMaxHight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (player == null)
        {
            return;
        }

        playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);


        if(player.transform.localScale.x > 0f)
        {
            yoffset = Mathf.Clamp(playerPosition.y + offset, 0, CameraMaxHight);
            playerPosition = new Vector3(playerPosition.x + offset, yoffset, playerPosition.z);

        }
        else
        {
            yoffset = Mathf.Clamp(playerPosition.y - offset, 0, CameraMaxHight);
            playerPosition = new Vector3(playerPosition.x - offset, yoffset, playerPosition.z);
        }

        transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);

    }
}
