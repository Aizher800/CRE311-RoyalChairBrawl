using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public UI_HealthBar healthBar; //Ref to HealthBar script.

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
            Debug.Log("Light attack");
            TakeDamage(2); //light 
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Heavy attack");
            TakeDamage(5);  //heavy
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Super attack");
            TakeDamage(10); //super
        }
    }


    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth); //Adjusting health bar according to health.
    }
}
