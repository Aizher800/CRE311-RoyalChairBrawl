using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    //Based on a tut: https://www.studica.com/blog/create-ui-unity-tutorial
    


    [SerializeField]    //What does this do? From research I understand it will display things in Inspector.
    Transform UIPanel;  //Pause menu enabling/disabling.

    [SerializeField]
    Time timeText;      //Modifying the text displayed.
       
    bool isPaused;


    void Start()
    {
        UIPanel.gameObject.SetActive(false);    //Prevents panel from appearing at start of scene.
        isPaused = false;                       //Game is not paused ordinarily.
    }

    
    void Update()
    {
        //timeText.text = "Time Since Startup: " + Time.timeSinceLevelLoad;   //Time since scene start. REMOVE this feature later.

        if(Input.GetKeyDown(KeyCode.Escape) && !isPaused)       //While game isn't paused, the player can press esc and it will pause game.
        {
            Pause();
        }

        else if(Input.GetKeyDown(KeyCode.Escape) && isPaused)   //While the game is paused, the player can press esc and it will resume game.
        {
            UnPause();
        }
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


    public void QuitGame()
    {
        Debug.Log("Game quit.");
        Application.Quit();
    }


    public void Restart()
    {
        Debug.Log("Game restarted.");
        SceneManager.LoadScene(0);   //Set this to whatever current scene it's on. Our game should only be one scene?
    }

    
}
