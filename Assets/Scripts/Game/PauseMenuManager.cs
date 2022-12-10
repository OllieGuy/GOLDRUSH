using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenuManager : MonoBehaviour
{
    private GameObject pauseMenu;
    private GameObject crosshair;
    public void Start() //set the pause menu to initially not be active
    {
        pauseMenu = GameObject.Find("PauseCanvas");
        crosshair = GameObject.Find("Crosshair");
        pauseMenu.SetActive(false);
    }
    public void pauseGame()
    {
        Time.timeScale = 0; //stop enemies and player from moving, since it operates on time.deltatime
        Cursor.visible = true; //re-enable the mouse
        crosshair.SetActive(false); //stops the crosshair logic, which stops player just shooting as many times as they want, with the bullets moving once the game is unpaused
        pauseMenu.SetActive(true);
    }
    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
    public void resume()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        crosshair.SetActive(true); //re-enable shooting
        pauseMenu.SetActive(false); //close the pause menu
    }
}
