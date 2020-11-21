using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using _InputTest.Entity.Scripts.Input.Monobehaviours;

public class HealthBarScript : MonoBehaviour
{

   

    public int health;
    public int maxHealth;
    public int abilityP;
    public PlayerInputNum playerNum;

    public Text charName;
    public string charText;


    public Text winTimer;
    public string winTimerString;
    public Image[] healthbar;
    public Image[] apBar;

    public GameObject instancedCharacter;

    public  void OnLoad()
    {
        health = maxHealth;
        UpdateHealth();
        Erin_UI_PlayerHealth.OnHealthUpdate += SetHealth;

        charName.text = charText;

    }
    void Start()
    {
        health = maxHealth;
        UpdateHealth();
       Erin_UI_PlayerHealth.OnHealthUpdate += SetHealth;

        charName.text = charText;
    }
    public void UpdateTimer(string newTimer)
    {
        Debug.Log("UPDATED TIMER");
        winTimer.text = newTimer;
    }
    void UpdateHealth()
    {

        // Health system
        for (int i = 0; i < healthbar.Length; i++)
        {
            if (i < health)
            {
                healthbar[i].enabled = true;
            }
            else
            {
                healthbar[i].enabled = false;
            }
        }

        // Ability Power system
        for (int i = 0; i < apBar.Length; i++)
        {
            if (i < abilityP)
            {
                apBar[i].enabled = true;
            }
            else
            {
                apBar[i].enabled = false;
            }
        }
    }

    public void SetHealth(PlayerInputNum _num, int _newHealth, int _newEnergy)
    {
        if (_num != playerNum) { return; }
        health = _newHealth;
        abilityP = _newEnergy;
        if (health <= 0)
        {
            Debug.Log(instancedCharacter + " has died");
        }
        UpdateHealth();
    }
    public void healthOverheal()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        UpdateHealth();
    }
    public void loseHealth(int loss)
    {
        Debug.Log("char health loss run damage was" + loss);
        health -= loss;
        Debug.Log("health is now" + health);
        UpdateHealth();
    }

    public void gainHealth(int gain)
    {
        health += gain;
        healthOverheal();
        UpdateHealth(); //i probably dont need to update health twice 

    }
}