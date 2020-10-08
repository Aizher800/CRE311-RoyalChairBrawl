using UnityEngine;

public class Erin_UI_PlayerHealth : MonoBehaviour
{
    // Based on tut. : https://www.youtube.com/watch?v=BLfNP4Sc_iA

    public int maxHealth = 100;
    public int currentHealth;

    public Erin_UI_HealthBar healthBar; //Ref to HealthBar script.

    void Start()
    {
        currentHealth = maxHealth;

        healthBar.SetMaxHealth(maxHealth);  //Setting up health bar.
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Weapon")
        {
            Debug.Log("Light attack");
            TakeDamage(2); //light 
        }
    }


    void Update()
    {
        //Trigger for damage - Needs to change to collision with other players weapons etc.
        //if(Input.GetKeyDown(KeyCode.Q))  
        //{
        //    Debug.Log("Light attack");
        //    TakeDamage(2); //light 
        //}

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Heavy attack");
            TakeDamage(5);  //heavy
        }

        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    Debug.Log("Super attack");
        //    TakeDamage(10); //super
        //}

        if (currentHealth == 0)
        {
            //run the death animation
            //despawn after x seconds of animation
        }
    }


    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth); //Adjusting health bar according to health.
    }
}
