using UnityEngine;

public class Erin_UI_PlayerHealth : MonoBehaviour
{
    // Based on tut. : https://www.youtube.com/watch?v=BLfNP4Sc_iA

    public int maxHealth = 100;
    public int currentHealth;

   // public Erin_UI_HealthBar healthBar; //Ref to HealthBar script.

    public GameObject healthPrefab;
   public HealthBarScript characterHealth;
    public HealthContainerPanel containerPanel;
    void Start()
    {
        containerPanel = FindObjectOfType<HealthContainerPanel>();
        characterHealth = Instantiate(healthPrefab, containerPanel.transform).GetComponent<HealthBarScript>();
        
    }

    void OnCollisionEnter(Collision col)
    {
     
    }


    void Update()
    {
      
    }

    public void AddHealth(int amount)
    {
        characterHealth.gainHealth(amount);
    }
    public void RemoveHealth(int damage)
    {
        characterHealth.loseHealth(damage);

    
        //  healthBar.SetHealth(currentHealth); //Adjusting health bar according to health.
    }
}
