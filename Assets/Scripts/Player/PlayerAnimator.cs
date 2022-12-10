using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.PlayerSettings;

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
        Sprite[] framesToUse; //uses a temporary variable to pass the right set of frames to the draw script
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
        transform.position = player.location; //the position of the sprite is set to the player
    }
    private void Draw(Sprite[] frames)
    {
        timer += Time.deltaTime; //uses a timer to change the frames
        if (player.idle) //if the player isnt doing anything, play the idle animation of the current set of frames
        {
            if (timer >= 0.75f)
            {
                timer -= 0.75f;
                currentFrame = (currentFrame + 1) % 2;
                spriteRenderer.sprite = frames[currentFrame];
            }
        }
        else //if the player is doing something, play the movement animation of the current set of frames
        {
            if (timer >= 0.15f)
            {
                timer -= 0.15f;
                currentFrame = (currentFrame + 1) % 2;
                if (player.facingCamera == "sideR")
                {
                    spriteRenderer.flipX = true; //makes the player turn towards the right if they are going right, rather than using a different set of frames
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
