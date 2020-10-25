using UnityEngine;
using _InputTest.Entity.Scripts.Input.Monobehaviours;
public class Erin_UI_PlayerHealth : MonoBehaviour
{
    // Based on tut. : https://www.youtube.com/watch?v=BLfNP4Sc_iA

    public delegate void UpdateHealthEvent(PlayerInputNum num, int newHealth, int newEnergy);
    public static event UpdateHealthEvent OnHealthUpdate;


    public int maxHealth = 100;
    public int currentHealth = 6;

    [SerializeField] public PlayerInputNum associatedPlayerNum;
   // public Erin_UI_HealthBar healthBar; //Ref to HealthBar script.

    [SerializeField] public GameObject healthPrefab;
   public HealthBarScript characterHealth;
    public HealthContainerPanel containerPanel;

    GameObject associatedUIObject;
    public void OnSpawn()
    {
       
        containerPanel = FindObjectOfType<HealthContainerPanel>();
      var instance =  Instantiate(healthPrefab, containerPanel.transform);
        if (instance != null) { Debug.Log("health instance exists"); }
        characterHealth = instance.GetComponent<HealthBarScript>();
        characterHealth.playerNum = associatedPlayerNum;
        if (characterHealth == null)
        {
            Debug.Log("couldnt get refernececeec");
        }
        else
        {
            Debug.Log("have a reference i do");
        }
    }

    void OnCollisionEnter(Collision col)
    {
     
    }


    void Update()
    {
      
    }

    public void AddHealth(int amount)
    {
        currentHealth += amount;
       
    }
    public void RemoveHealth(int amount)
    {
        Debug.Log("erin health loss run damage was" + amount);
        currentHealth -= amount;
        if (characterHealth != null) {
            Debug.Log("setting char health which is not null");
           OnHealthUpdate(associatedPlayerNum, amount, 1);
        }
        else
        {
            if (associatedUIObject == null)
            {
                Debug.Log("AAAAAAAAYEEEEEEEE");
            }
        }


        //  healthBar.SetHealth(currentHealth); //Adjusting health bar according to health.
    }
}
