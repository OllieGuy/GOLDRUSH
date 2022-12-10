using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interest : MonoBehaviour
{
    public GameObject obj;
    public GameObject pfInterestArea;
    public bool hit = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet") //if a bullet hits a stick (or another object that would trigger interest if it were to be added)
        {
            Instantiate(pfInterestArea, obj.transform.position, Quaternion.Euler(0f,0f,0f)); //create an area of interest
            Destroy(obj);
        }
    }
}
