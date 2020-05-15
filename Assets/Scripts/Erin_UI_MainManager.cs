using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Erin_UI_MainManager : MonoBehaviour
{
    void Start()
    {
    
    }
 

    void Update()
    {
        
    }


    public void StartGame()
    {
        Debug.Log("Game started.");
        SceneManager.LoadScene(4);   //Loads in the scene that has a pause menu.
    }


    public void Tutorial()
        {
            Debug.Log("Tutorial loaded.");
            SceneManager.LoadScene(2);   //Loads in the tutorial scene.
        }


    public void Settings()
    {
        Debug.Log("Settings loaded.");
        SceneManager.LoadScene(3);   //Loads in the scene that has settings.
    }


    public void Return()
    {
        Debug.Log("Main menu loaded.");
        SceneManager.LoadScene(1);   //Returns the user back to main menu.
    }
}
