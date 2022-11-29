using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public GameObject healthedObject;
    private Rigidbody2D rb;

    void Update()
    {
        if (health <= 0)
        {
            Destroy(healthedObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //Collision c = other.gameObject.GetComponent<Collision>();
        if (other.gameObject.tag == "Bullet")
        {
            health -= 1;
            //Vector2 dir = c.contacts[0].point - transform.position;
            //float force = 2f;
            //rb.AddForce(dir * force, ForceMode2D.Impulse);
            Destroy(other.gameObject);
            Debug.Log("asdf");
        }
    }
}
