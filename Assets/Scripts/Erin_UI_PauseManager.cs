using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Erin_UI_PauseManager : MonoBehaviour
{
    //Based on tuts. Pause menu: https://www.studica.com/blog/create-ui-unity-tutorial
    //                Main menu: https://www.raywenderlich.com/6570-introduction-to-unity-ui-part-1
    //              Enabling UI: https://answers.unity.com/questions/1637497/how-to-show-and-hide-an-ui-canvas-element-in-2019.html



    [SerializeField]    //What does this do? From research I understand it will display things in Inspector.
    Transform UIPanel;  //Pause menu enabling/disabling.

    [SerializeField]
    Time timeText;      //Modifying the text displayed.

    bool isPaused;

    public GameObject Hud;    //HUD enabling/disabling.

    void Start()
    {

        UIPanel.gameObject.SetActive(false);    //Prevents panel from appearing at start of scene.
        isPaused = false;                       //Game is not paused ordinarily.

        Hud.gameObject.SetActive(true);   //HUD enabled.

        Debug.Log("Game started.");
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)       //While game isn't paused, the player can press esc and it will pause game.
        {
            Pause();
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)   //While the game is paused, the player can press esc and it will resume game.
        {
            UnPause();
        }
    }


    public void Pause()
    {
        isPaused = true;
        UIPanel.gameObject.SetActive(true);     //Enables the panel.
        Time.timeScale = 0f;                    //Pauses game.

        Hud.gameObject.SetActive(false);   //HUD disabled.
    }


    public void UnPause()
    {
        isPaused = false;
        UIPanel.gameObject.SetActive(false);    //Disables the panel.
        Time.timeScale = 1f;                    //Resumes game.

        Hud.gameObject.SetActive(true);   //HUD enabled.
    }


    public void Restart()
    {
        Debug.Log("Game restarted.");
        SceneManager.LoadScene(0);   //Loads in the main menu scene.
    }


    public void QuitGame()
    {
        Debug.Log("Game quit.");
        Application.Quit();
    }


}
