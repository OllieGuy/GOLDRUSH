using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Vector2 currentCentre;
    private Vector3 viewPos;
    private float[] bounds = {0,0,0,0 };
    private float[] boundMargin = { 1.0f, 0.6f }; //the smaller these numbers, the closer the bound to the player
    public GameObject player;
    public Camera cam;
    void Start()
    {
        currentCentre = new Vector2(0f, 0f);
        viewPos = player.transform.position;
        viewPos.z = -10;
        cam.transform.position = viewPos;
    }

    void LateUpdate() //moves the camera just after the player
    {
        //sets the bounds of the current position
        bounds[0] = currentCentre.x - boundMargin[0];
        bounds[1] = currentCentre.x + boundMargin[0];
        bounds[2] = currentCentre.y + boundMargin[1];
        bounds[3] = currentCentre.y - boundMargin[1];
        viewPos.z = -10;
        //when the player reaches a bound of the playable area on the screen, reset the bounds to the new position and move the camera
        if (player.transform.position.x < bounds[0])
        {
            currentCentre.x -= (bounds[0] - player.transform.position.x);
            viewPos.x = player.transform.position.x + boundMargin[0];
        }
        if (player.transform.position.x > bounds[1])
        {
            currentCentre.x += (player.transform.position.x - bounds[1]);
            viewPos.x = player.transform.position.x - boundMargin[0];
        }
        if (player.transform.position.y > bounds[2])
        {
            currentCentre.y += (player.transform.position.y - bounds[2]);
            viewPos.y = player.transform.position.y - boundMargin[1];
        }
        if (player.transform.position.y < bounds[3])
        {
            currentCentre.y -= (bounds[3] - player.transform.position.y);
            viewPos.y = player.transform.position.y + boundMargin[1];
        }
        cam.transform.position = viewPos;
    }
}
