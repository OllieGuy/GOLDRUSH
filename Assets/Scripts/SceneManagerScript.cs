using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerScript : MonoBehaviour
{
    public GameObject options;
    public static Player player;
    public static int gold = 0;
    public static bool win;
    public static float spaceToFill = 2f;
    public static float enemyBufferSpace = 0.3f;
    public static int amountOfRandomObjects = 50;
    public static int amountOfGoldPiles = 4;
    public static int maxEnemiesPerPile = 5;
    public static int enemyTotal = 0;
    private void Start()
    {
        if (options != null)
        {
            options.SetActive(false);
        }
    }
    public void StartGame()
    {
        options.SetActive(true);
        UpdateOptions();
        SceneManager.LoadScene("Game");
    }
    public void QuitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
    public static void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public static void PlayerDeath()
    { 
        UnityEngine.Cursor.visible = true;
        SceneManager.LoadScene("EndScreen");
    }
    public void Options()
    {
        if (options.active)
        {
            options.SetActive(false);
        }
        else
        {
            options.SetActive(true);
        }
    }
    public void UpdateOptions()
    {
        Slider spaceToFillSlider = GameObject.Find("spaceToFillSlider").GetComponent<Slider>();
        spaceToFill = spaceToFillSlider.value;
        Slider enemyBufferSpaceSlider = GameObject.Find("enemyBufferSpaceSlider").GetComponent<Slider>();
        enemyBufferSpace = enemyBufferSpaceSlider.value;
        Slider amountOfRandomObjectsSlider = GameObject.Find("amountOfRandomObjectsSlider").GetComponent<Slider>();
        amountOfRandomObjects = (int)amountOfRandomObjectsSlider.value;
        Slider amountOfGoldPilesSlider = GameObject.Find("amountOfGoldPilesSlider").GetComponent<Slider>();
        amountOfGoldPiles = (int)amountOfGoldPilesSlider.value;
        Slider maxEnemiesPerPileSlider = GameObject.Find("maxEnemiesPerPileSlider").GetComponent<Slider>();
        maxEnemiesPerPile = (int)maxEnemiesPerPileSlider.value;
    }
    public static bool CheckIfGoldLeft()
    {
        if (GameObject.Find("pfAnchorPoint(Clone)") == null && GameObject.Find("pfGoldBar(Clone)") == null && enemyTotal == 0)
        {
            win = true;
            UnityEngine.Cursor.visible = true;
            SceneManager.LoadScene("EndScreen");
        }
        return true;
    }
}
