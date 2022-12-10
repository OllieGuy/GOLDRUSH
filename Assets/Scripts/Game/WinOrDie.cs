using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinOrDie : MonoBehaviour
{
    void Start() //called on the end screen to figure out if the player has won or lost
    {
        GameObject winText = GameObject.Find("You Win!");
        GameObject loseText = GameObject.Find("You Died");
        if (SceneManagerScript.win)
        {
            winText.SetActive(true);
            loseText.SetActive(false);
        }
        else
        {
            winText.SetActive(false);
            loseText.SetActive(true);
        }
    }
}
