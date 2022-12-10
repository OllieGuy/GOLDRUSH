using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pfGenericDecorationScript : MonoBehaviour
{
    //select a random sprite from the given set of sprites for a decoration object
    [SerializeField] private Sprite[] ObjectSprite;
    public SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        int selectedSprite = Random.Range(0, ObjectSprite.Length);
        spriteRenderer.sprite = ObjectSprite[selectedSprite];
    }
}
