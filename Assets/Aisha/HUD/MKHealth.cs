using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MKHealth : MonoBehaviour
{

    public int health;
    public int maxHealth;
    public int abilityP;

    public Image[] healthbar;
    public Image[] apBar;

    void Start()
    {
        health = maxHealth;
    }

    void Update()
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
    }
    public void loseHealth(int loss)
    {
        health -= loss;
    }

    public void gainHealth(int gain)
    {
        health += gain;
        healthOverheal();
    }
}