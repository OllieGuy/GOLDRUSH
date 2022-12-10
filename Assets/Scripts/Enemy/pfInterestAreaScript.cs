using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pfInterestAreaScript : MonoBehaviour
{
    private float timer = 0f;
    public GameObject InterestArea;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1f) //the interest exists for one second so that an enemy passing through the area just after can also pick up on it
        {
            Destroy(InterestArea);
        }
    }
}
