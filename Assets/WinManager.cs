using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WinManager : MonoBehaviour
{


    public int WinScore;

    public int currentScore;
   [SerializeField] Text text;
   [SerializeField] GameObject WinObject;

    public void WinGame(string player)
    {
        WinObject.SetActive(true);
        text.text = (player + "WINS!");

    }
}
