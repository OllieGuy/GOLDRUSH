using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Sprite[] healthSprites;
    [SerializeField] private Player player;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        Sprite frameToUse;
        frameToUse = healthSprites[3 - player.health];
        spriteRenderer.sprite = frameToUse;
    }
}
