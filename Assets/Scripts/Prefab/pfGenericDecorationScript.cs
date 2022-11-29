using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pfGenericDecorationScript : MonoBehaviour
{
    [SerializeField] private Sprite[] ObjectSprite;
    public SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        int selectedSprite = Random.Range(0, ObjectSprite.Length);
        spriteRenderer.sprite = ObjectSprite[selectedSprite];
    }

    void Update()
    {
        
    }
}
