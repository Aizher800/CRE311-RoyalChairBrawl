using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WinManager : MonoBehaviour
{


    public int WinScore;

    public int currentScore;
   [SerializeField] TMP_Text text;
   [SerializeField] GameObject WinObject;

    public void TimeUp()
    {
        //the timescale things might not be a good thing here
        Time.timeScale = 0f;
        WinObject.SetActive(true);
        text.text = ("TIMES UP!");

    }
    public void WinGame(string player)
    {
        Time.timeScale = 0f;
        WinObject.SetActive(true);
        text.text = (player + "WINS!");

    }
}
