using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CrosshairShooting : MonoBehaviour
{
    [SerializeField] private Sprite[] crosshairs;
    [SerializeField] private Transform pfBullet;
    private int levelLayer;
    private bool available;
    public GameObject Player;
    public Gunno Gunno;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        available = true;
        UnityEngine.Cursor.visible = false; //stop showing the mouse
        levelLayer = LayerMask.GetMask("Obstacle"); //get the layer with the obstacles - this is so that the game can be expanded for more obstacles
    }
    void Update()
    {
        Vector2 mouseCursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerCurrentpos = Player.transform.position;
        transform.position = mouseCursorPos; //keep the crosshair where the mouse is
        Vector2 diffInPos = mouseCursorPos - playerCurrentpos;
        checkShootable(playerCurrentpos, diffInPos);
        if (Input.GetMouseButtonDown(0)) //shoot when the player clicks
        {
            shoot(playerCurrentpos);
        }
    }
    void checkShootable(Vector2 playerCurrentpos, Vector2 diffInPos) //checks if the raycast between the player and the crosshair is broken
    {
        RaycastHit2D hit = Physics2D.Raycast(playerCurrentpos, diffInPos, diffInPos.magnitude, levelLayer);
        if (!hit && available) //the bool available essentially makes this be a toggle
        {
            UnityEngine.Debug.DrawRay(playerCurrentpos, diffInPos, Color.red, 0.0f);
        }
        else if (!hit && !available)
        {
            spriteRenderer.sprite = crosshairs[0];
            available = true;
        }
        else if (hit && available)
        {
            spriteRenderer.sprite = crosshairs[1];
            available = false;
        }
    }
    void shoot(Vector2 playerCurrentpos) //create a bullet then add force to it
    {
        float force = 2f;
        GameObject newBullet = Instantiate(pfBullet, playerCurrentpos, Quaternion.Euler(new Vector3(0f, 0f, Gunno.returnAng()))).GameObject();
        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(newBullet.transform.up * force, ForceMode2D.Impulse);
    }
}