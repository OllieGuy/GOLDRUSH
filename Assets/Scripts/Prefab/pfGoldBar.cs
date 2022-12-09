using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pfGoldBar : MonoBehaviour
{
    public float spinSpeed = 100.0f;
    private void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * spinSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Debug.Log("dinggg");
            Destroy(collision.gameObject);
        }
    }
}
