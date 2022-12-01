using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class HealthBar : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] GameObject Bar;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void UpdateBar(int health, int maxHealth)
    {
        Bar.transform.localScale = new Vector3((float)health / (float)maxHealth, 1, 1);
        if (health < maxHealth/2)
        {
            spriteRenderer.color = UnityEngine.Color.yellow;
        }
        if (health < maxHealth / 4)
        {
            spriteRenderer.color = UnityEngine.Color.red;
        }
    }
}
