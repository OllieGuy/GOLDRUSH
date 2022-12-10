using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pfGoldBar : MonoBehaviour
{
    public float spinSpeed = 100.0f; //makes it so the gld bar can have a spin animation
    private void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * spinSpeed); //animate the gold bar spinning
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet") //eat bullets
        {
            Destroy(collision.gameObject);
        }
    }
}
