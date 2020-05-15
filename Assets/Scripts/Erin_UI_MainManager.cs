﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Erin_UI_MainManager : MonoBehaviour
{
    void Start()
    {
        /*  Keeping this for inspo, in case we need to combine Manager scripts. - EW 5/5/20
         *
         *  Need a way to check what scene is currently active, and enable/disable the different scene panels. 
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
    }
 

    void Update()
    {
        
    }


    public void StartGame()
    {
        Debug.Log("Game started.");
        SceneManager.LoadScene(0);   //Loads in the scene that has a pause menu.
    }

    public void Tutorial()
        {
            Debug.Log("Tutorial scene loaded.");
            SceneManager.LoadScene(2);   //Loads in the scene that has settings.
        }

    //public void Settings()
    //{
    //    SceneManager.LoadScene(x);   //Loads in the scene that has settings.
    //}
}
