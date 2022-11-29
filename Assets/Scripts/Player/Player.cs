using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 0.5f;
    public string facingCamera;
    public bool idle;
    public int health;
    public Vector2 location;
    void Start()
    {
        facingCamera = "sideR";
        idle = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        if (Input.GetKey("w"))
        {
            pos.y += speed * Time.deltaTime;
            facingCamera = "back";
        }
        if (Input.GetKey("s"))
        {
            pos.y -= speed * Time.deltaTime;
            facingCamera = "front";
        }
        if (Input.GetKey("d"))
        {
            pos.x += speed * Time.deltaTime;
            facingCamera = "sideR";
        }
        if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
            facingCamera = "sideL";
        }
        if (Input.anyKey)
        {
            idle = false;
        }
        else
        {
            idle = true;
        }
        //Debug.Log(pos);
        //pos = pos.normalized;
        transform.position = pos;
        location = pos;
    }
}
