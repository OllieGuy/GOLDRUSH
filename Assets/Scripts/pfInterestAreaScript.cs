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
        if (timer > 1f)
        {
            Destroy(InterestArea);
        }
    }
}
