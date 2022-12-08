using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pfAnchorPoint : MonoBehaviour
{
    [SerializeField] private Sprite[] ObjectSprite;
    public SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        int selectedSprite = Random.Range(0, ObjectSprite.Length);
        spriteRenderer.sprite = ObjectSprite[selectedSprite];
        tag = "GoldPile";
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Debug.Log("dinggg");
            Destroy(collision.gameObject);
        }
    }
}
