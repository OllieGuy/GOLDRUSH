using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CrosshairMechanics : MonoBehaviour
{
    [SerializeField] private Sprite[] crosshairs;
    [SerializeField] private Transform pfBullet;
    private RaycastHit hitObject;
    private int levelLayer;
    private bool available;
    public GameObject Player;
    public Gunno Gunno;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        available = true;
        UnityEngine.Cursor.visible = false;
        levelLayer = LayerMask.GetMask("Obstacle");
    }
    void Update()
    {
        Vector2 mouseCursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerCurrentpos = Player.transform.position;
        transform.position = mouseCursorPos;
        Vector2 diffInPos = mouseCursorPos - playerCurrentpos;
        checkShootable(playerCurrentpos, diffInPos);
        if (Input.GetMouseButtonDown(0))
        {
            shoot(playerCurrentpos, diffInPos);
        }
    }
    void checkShootable(Vector2 playerCurrentpos, Vector2 diffInPos)
    {
        RaycastHit2D hit = Physics2D.Raycast(playerCurrentpos, diffInPos, diffInPos.magnitude, levelLayer);
        if (!hit && available)
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
    void shoot(Vector2 playerCurrentpos, Vector2 diffInPos)
    {
        float force = 2f;
        //UnityEngine.Debug.Log("bang");
        GameObject newBullet = Instantiate(pfBullet, playerCurrentpos, Quaternion.Euler(new Vector3(0f, 0f, Gunno.returnAng()))).GameObject();
        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(newBullet.transform.up * force, ForceMode2D.Impulse);
    }
}