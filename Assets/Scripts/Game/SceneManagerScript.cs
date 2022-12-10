using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerScript : MonoBehaviour
{
    //sets up the variables that need to be accessed by a number of scripts, including the menu and level creator
    public GameObject options;
    public static Player player;
    public static int gold = 0;
    public static bool win;
    public static float spaceToFill = 2f;
    public static float enemyBufferSpace = 0.3f;
    public static int amountOfRandomObjects = 50;
    public static int amountOfGoldPiles = 4;
    public static int maxEnemiesPerPile = 5;
    public static int enemyTotal = 0; //enemy total needs to be reset between plays, so it is set here
    private void Start()
    {
        if (options != null)
        {
            options.SetActive(false);
        }
    }
    public void StartGame()
    {
        options.SetActive(true); //activate the options so that they can be passed into the level creator
        UpdateOptions();
        SceneManager.LoadScene("Game"); //load the main game
    }
    public void QuitGame()
    {
        Debug.Log("Quitting");
        Application.Quit(); //shut the game
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
        if (options.activeInHierarchy) //makes the options pannel toggleable
        {
            options.SetActive(false);
        }
        else
        {
            options.SetActive(true);
        }
    }
    public void UpdateOptions() //sets the values to those assigned in the options pannel
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
    public static bool CheckIfGoldLeft() //checks if there is the potential for the player to get any more gold, if not, the player wins the game and it goes to the end screen
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
