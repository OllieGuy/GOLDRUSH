using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GoldCounter : MonoBehaviour
{
    //counts the gold during the game and on the end screen
    [SerializeField] private Player player;
    [SerializeField] private Text text;
    void Start()
    {
        text = gameObject.GetComponent<Text>();
        if (player == null)
        {
            player = SceneManagerScript.player;
        }
    }

    void Update()
    {
        text.text = SceneManagerScript.gold.ToString();
    }
}
