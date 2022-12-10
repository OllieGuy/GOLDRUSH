using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 0.5f; //player speed
    public string facingCamera;
    public bool idle;
    public int health;
    public BoxCollider2D characterHitbox;
    public Vector2 location;
    void Start()
    {
        SceneManagerScript.gold = 0; //when the game starts, gold is set to 0
        SceneManagerScript.win = false; //the player hasn't won... yet!
        characterHitbox = GetComponent<BoxCollider2D>();
        facingCamera = "sideR"; //the default frames are the player facing to the right before they do anything. Why, you ask? I just thought it looked the best
        idle = false;
        health = 3;
    }

    void Update()
    {
        Vector2 pos = transform.position;
        //when the player press the WSAD keys, move them in the corresponding direction
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
            idle = false; //this does make it activate the walking frames when the player is shooting, but it works otherwise
        }
        else
        {
            idle = true;
        }
        SceneManagerScript.CheckIfGoldLeft(); //makes sure the game isnt over
        transform.position = pos;
        location = pos;
    }
    public void OnTriggerEnter2D(Collider2D collision) //looks at what the player is touching if a hitbox is hit
    {
        //uses characherHitbox, since there is a larger circular hitbox that the enemies detect
        if (collision.tag == "EnemyBullet" && collision.IsTouching(characterHitbox))
        {
            health -= 1;
            Destroy(collision.gameObject);
        }
        if (collision.tag == "GoldPile" && collision.IsTouching(characterHitbox))
        {
            SceneManagerScript.gold += 5;
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Gold" && collision.IsTouching(characterHitbox))
        {
            SceneManagerScript.gold += 1;
            Destroy(collision.gameObject);
        }
    }
}
