using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerScore : MonoBehaviour
{
    WinManager winManager;
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public bool hasChair = false;
    public TMP_Text timeText;
    public int playerScore;
    Matt_SM_PlayerStateInfo _ownerr;
   public HealthBarScript associatedHealth;
    // Start is called before the first frame update
    void Start()
    {
        _ownerr = GetComponent<Matt_SM_PlayerStateInfo>();
        winManager = FindObjectOfType<WinManager>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hasChair)
        {

            playerScore++;
        }
    }

    void Update()
    {
        if (hasChair)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
                associatedHealth.UpdateTimer(timeRemaining.ToString());
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                winManager.WinGame(gameObject.name);
                timerIsRunning = false;
            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        // timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        associatedHealth.UpdateTimer(timeToDisplay.ToString());
      //  timeText.text = timeToDisplay.ToString();
    }
}
