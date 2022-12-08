using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pfBulletBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject pfBullet;
    private float time = 0f;
    void Update()
    {
        time = time + Time.deltaTime;
        if (time > 5f)
        {
            Destroy(pfBullet);
        }
    }
}
