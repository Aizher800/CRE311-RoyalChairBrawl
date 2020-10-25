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

    public Image[] healthbar;
    public Image[] apBar;

    void Start()
    {
        health = maxHealth;
        UpdateHealth();
       GameManager.OnHealthUpdate += SetHealth;
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