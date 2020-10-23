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

    public Image[] healthbar;
    public Image[] apBar;

    void Start()
    {
        health = maxHealth;
        UpdateHealth();
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
        health -= loss;
        UpdateHealth();
    }

    public void gainHealth(int gain)
    {
        health += gain;
        healthOverheal();
        UpdateHealth(); //i probably dont need to update health twice 

    }
}