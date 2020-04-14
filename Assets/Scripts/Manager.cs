using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    //Based on tuts. Pause menu: https://www.studica.com/blog/create-ui-unity-tutorial
    //                Main menu: https://www.raywenderlich.com/6570-introduction-to-unity-ui-part-1



    [SerializeField]    //What does this do? From research I understand it will display things in Inspector.
    Transform UIPanel;  //Pause menu enabling/disabling.

    [SerializeField]
    Time timeText;      //Modifying the text displayed.
       
    bool isPaused;


    void Start()
    {
        /*  Need a way to check what scene is currently active, and enable/disable the different scene panels. 
         *  Could use 'GetActiveScene' static.
         *  
         *   if(scene with pause loaded)
         *   {
         *         Panel is false/disabled.
         *   }
         *   
         *   else(menu scene loaded)
         *   {
         *          Panel is true/enabled.
         *   }
         *   
         *   Could just use a separate manager script for each scene.
        */
        UIPanel.gameObject.SetActive(false);    //Prevents panel from appearing at start of scene.
        isPaused = false;                       //Game is not paused ordinarily.
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !isPaused)       //While game isn't paused, the player can press esc and it will pause game.
        {
            Pause();
        }

        else if(Input.GetKeyDown(KeyCode.Escape) && isPaused)   //While the game is paused, the player can press esc and it will resume game.
        {
            UnPause();
        }
    }


    public void StartGame()
    {
        SceneManager.LoadScene(0);   //Loads in the scene that has a pause menu.
    }
    

    public void Pause()
    {
        isPaused = true;
        UIPanel.gameObject.SetActive(true);     //Enables the panel.
        Time.timeScale = 0f;                    //Pauses game.
    }


    public void UnPause()
    {
        isPaused = false;
        UIPanel.gameObject.SetActive(false);    //Disables the panel.
        Time.timeScale = 1f;                    //Resumes game.
    }


    public void Restart()
    {
        Debug.Log("Game restarted.");
        SceneManager.LoadScene(1);   //Loads in the main menu scene.
    }


    public void QuitGame()
    {
        Debug.Log("Game quit.");
        Application.Quit();
    }


}
