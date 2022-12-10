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
    private void Update() //change the health UI elements in accordance with the player's current health
    {
        Sprite frameToUse;
        frameToUse = healthSprites[3 - player.health];
        spriteRenderer.sprite = frameToUse;
        if (player.health <= 0)
        {
            SceneManagerScript.player = player;
            SceneManagerScript.PlayerDeath(); //player has died, so play the end screen
        }
    }
}
