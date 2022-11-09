using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CrosshairMechanics : MonoBehaviour
{
    [SerializeField] private Sprite[] crosshairs;
    [SerializeField] private Transform pfBullet;
    private RaycastHit hitObject;
    private float rayLength;
    private int levelLayer;
    private bool available;
    public GameObject Player;
    public SpriteRenderer spriteRenderer; 
    public Sprite bullet;

    void Start()
    {
        available = true;
        Cursor.visible = false;
        levelLayer = LayerMask.GetMask("Obstacle");
    }
    void Update()
    {
        Vector2 mouseCursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerCurrentpos = Player.transform.position;
        transform.position = mouseCursorPos;
        checkShootable(playerCurrentpos);
        if (Input.GetMouseButtonDown(0))
        {
            shoot();
        }
    }
    void checkShootable(Vector2 playerCurrentpos)
    {
        Debug.Log(playerCurrentpos);
        Debug.Log(transform.position);
        RaycastHit2D hit = Physics2D.Raycast(playerCurrentpos, transform.position, Mathf.Infinity, levelLayer);
        if (!hit && available)
        {
            Debug.DrawRay(playerCurrentpos, transform.position, Color.red, 0.0f);
            Debug.Log("Shootable");
        }
        else if (!hit && !available)
        {
            Debug.Log("switching to on");
            spriteRenderer.sprite = crosshairs[0];
            available = true;
        }
        else if (hit && available)
        {
            Debug.Log("switching to off");
            spriteRenderer.sprite = crosshairs[1];
            available = false;
        }
    }
    void shoot()
    {
        if (available)
        {
            Debug.Log("bang");
            Debug.Log(this.transform.position);
            Instantiate(pfBullet, this.transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("click");
        }
    }
}
