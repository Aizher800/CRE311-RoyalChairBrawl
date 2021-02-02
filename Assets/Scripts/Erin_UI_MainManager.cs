using UnityEngine;
using UnityEngine.SceneManagement;

public class Erin_UI_MainManager : MonoBehaviour
{
    public GameObject tutorialPanel;
    public GameObject tutorialControls;
    public GameObject tutorialGameplay;
    public GameObject tutorialInteractable;



    public void StartGame()
    {
        Debug.Log("Game started.");
        SceneManager.LoadScene(2);   //Loads in the scene that has a pause menu.
        GameManager._mainInstance.FindSpawns();
        GameManager._mainInstance.SpawnCharacters();
        Time.timeScale = 1f;
    }


    public void Tutorial()
    {
        Debug.Log("Tutorial loaded.");
        tutorialPanel.SetActive(true);

        //Opens Tutorial Canvas
    }

    public void CloseTutorial()
    {
        tutorialPanel.SetActive(false);
        tutorialControls.SetActive(true);
        tutorialGameplay.SetActive(false);
        tutorialInteractable.SetActive(false);
    }

    public void ToGameplay()
    {
        tutorialControls.SetActive(false);
        tutorialGameplay.SetActive(true);
    }
    public void ToInteractable()
    {
        tutorialGameplay.SetActive(false);
        tutorialInteractable.SetActive(true);
    }



    public void Settings()
    {
        Debug.Log("Settings loaded.");
        SceneManager.LoadScene(1);   //Loads in the scene that has settings.
    }


    public void Return()
    {
        Debug.Log("Main menu loaded.");
        SceneManager.LoadScene(0);   //Returns the user back to main menu.
    }

    //DECIDED TO MOVE THIS BUTTON 7/06/20
    public void QuitGame()
    {
        Debug.Log("Game quit.");
        Application.Quit();
    }
}
