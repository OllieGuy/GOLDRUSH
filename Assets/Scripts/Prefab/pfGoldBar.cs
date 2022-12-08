using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pfGoldBar : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Debug.Log("dinggg");
            Destroy(collision.gameObject);
        }
    }
}
