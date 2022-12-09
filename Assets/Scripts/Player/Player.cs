using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 0.5f;
    public string facingCamera;
    public bool idle;
    public int health;
    public BoxCollider2D characterHitbox;
    public Vector2 location;
    void Start()
    {
        SceneManagerScript.gold = 0;
        characterHitbox = GetComponent<BoxCollider2D>();
        facingCamera = "sideR";
        idle = false;
        health = 3;
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
        SceneManagerScript.CheckIfGoldLeft();
        transform.position = pos;
        location = pos;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
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
