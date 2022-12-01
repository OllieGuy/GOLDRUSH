using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interest : MonoBehaviour
{
    public GameObject obj;
    public GameObject pfInterestArea;
    public bool hit = false;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            Instantiate(pfInterestArea, obj.transform.position, Quaternion.Euler(0f,0f,0f));
            //Debug.Log("Crunch");
            Destroy(obj);
        }
    }
}
