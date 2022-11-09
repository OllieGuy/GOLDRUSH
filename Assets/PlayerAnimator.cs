using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Sprite[] framesFront;
    [SerializeField] private Sprite[] framesBack;
    [SerializeField] private Sprite[] framesSide;
    private int currentFrame;
    private float timer;
    private SpriteRenderer spriteRenderer;
    public Player player;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        Sprite[] framesToUse;
        if (player.facingCamera == "front")
        {
            framesToUse = framesFront;
        }
        else if (player.facingCamera == "back")
        {
            framesToUse = framesBack;
        }
        else
        {
            framesToUse = framesSide;
        }
        Draw(framesToUse);
        transform.position = player.location;
    }
    private void Draw(Sprite[] frames)
    {
        //Debug.Log(player.idle);
        timer += Time.deltaTime;
        if (player.idle)
        {
            if (timer >= 0.75f)
            {
                timer -= 0.75f;
                currentFrame = (currentFrame + 1) % 2;
                spriteRenderer.sprite = frames[currentFrame];
            }
        }
        else
        {
            if (timer >= 0.15f)
            {
                timer -= 0.15f;
                currentFrame = (currentFrame + 1) % 2;
                if (player.facingCamera == "sideR")
                {
                    spriteRenderer.flipX = true;
                }
                else
                {
                    spriteRenderer.flipX = false;
                }
                spriteRenderer.sprite = frames[currentFrame + 2];
            }
        }
    }
}
