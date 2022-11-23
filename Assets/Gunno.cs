using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunno : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public float rotation;
    public Player player;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector2 playerPos = player.transform.position;
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float mouseAngle = AngleBetweenTwoPoints(playerPos, mouseOnScreen);
        float angle = mouseAngle + 180;
        if (angle > 90 && angle <= 270)
        {
            spriteRenderer.flipX = false;
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, mouseAngle));
            transform.position = new Vector3(playerPos.x - 0.06f, playerPos.y - 0.03f, -0.01f);
            rotation = mouseAngle + 90;
        }
        else
        {
            spriteRenderer.flipX = true;
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
            transform.position = new Vector3(playerPos.x + 0.06f, playerPos.y - 0.03f, -0.01f);
            rotation = angle - 90;
        }
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    public float returnAng()
    {
        //Debug.Log(rotation);
        return rotation;
    }
}
