using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pfBulletBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject pfBullet;
    //private float damage = 1f;
    private float time = 0f;
    void Update()
    {
        time = time + Time.deltaTime;
        //Debug.Log(time);
        if (time > 5f)
        {
            Destroy(pfBullet);
        }
    }
}
