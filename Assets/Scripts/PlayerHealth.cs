using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar; //Ref to HealthBar script.

    void Start()
    {
        currentHealth = maxHealth;

        healthBar.SetMaxHealth(maxHealth);  //Setting up health bar.
    }

    
    void Update()
    {
        //Attacks - we can change the key codes to whatever is suitable.
        if(Input.GetKeyDown(KeyCode.Q)) //trigger for damage - Needs to change to collision with other players weapons etc.
        {
            TakeDamage(2); //light 
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(5);  //heavy
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            TakeDamage(10); //super
        }
    }


    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth); //Adjusting health bar according to health.
    }
}
