using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pfAnchorPoint : MonoBehaviour
{
    //select a random sprite from the given set of sprites for a decoration object
    [SerializeField] private Sprite[] ObjectSprite;
    public SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        int selectedSprite = Random.Range(0, ObjectSprite.Length);
        spriteRenderer.sprite = ObjectSprite[selectedSprite];
        tag = "GoldPile";
    }
    private void OnTriggerEnter2D(Collider2D collision) //stop bullets
    {
        if (collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);
        }
    }
}
