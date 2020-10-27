using UnityEngine;
using _InputTest.Entity.Scripts.Input.Monobehaviours;
using Matt_HitBoxSystem;
public class Erin_UI_PlayerHealth : MonoBehaviour
{
    // Based on tut. : https://www.youtube.com/watch?v=BLfNP4Sc_iA



    //RIPPED FROM ERIN'S HEALTH SCRIPT
    public int maxHealth = 6;
    public int currentHealth = 6;

    [SerializeField] public GameObject healthPrefab;
    public HealthBarScript characterHealth;

    public delegate void UpdateHealthEvent(PlayerInputNum num, int newHealth, int newEnergy);
    public static event UpdateHealthEvent OnHealthUpdate;

    GameObject associatedUIObject;
    [SerializeField] public PlayerInputNum associatedPlayerNum;
    // public Erin_UI_HealthBar healthBar; //Ref to HealthBar script.
    public void OnSpawn()
    {
     
      //  characterHealth = healthInstance.GetComponent<HealthBarScript>();
        //characterHealth.playerNum = inputChoices[i];
        //characterHealth.instancedCharacter = spawnedChar;


        HitReceiver.OnHealthChange += RemoveHealth;
        //if (instance != null) { Debug.Log("health instance exists"); }


        if (characterHealth == null)
        {
            Debug.Log("couldnt get refernececeec");
        }
        else
        {
            Debug.Log("have a reference i do");
        }
    }
    public void AddHealth(int amount)
    {
        currentHealth += amount;

    }
    public void RemoveHealth(int amount, PlayerInputNum _num)
    {
        //Debug.Log("erin health loss run damage was" + amount);
        //  Debug.Log("current health WAS " + currentHealth);

        if (_num == associatedPlayerNum) { 
            currentHealth = currentHealth + amount;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
            if (characterHealth != null)
            {
                Debug.Log("setting char health which is not null, current health is " + currentHealth);
                OnHealthUpdate(_num, currentHealth, 1);
            }
            else
            {
                if (associatedUIObject == null)
                {
                    Debug.Log("AAAAAAAAYEEEEEEEE");
                }
            }
        }

        if(currentHealth <= 0)
        {

            FindObjectOfType<GameManager>().RespawnCharacter(gameObject);
            GetComponent<Matt_CharacterEquipment>().UnequipItem(GetComponent<Matt_SM_PlayerStateInfo>());
            currentHealth = maxHealth;
            OnHealthUpdate(_num, currentHealth, 1);
          
            //Destroy(gameObject);
        }

        //  healthBar.SetHealth(currentHealth); //Adjusting health bar according to health.
    }

    void OnCollisionEnter(Collision col)
    {
     
    }


    void Update()
    {
      
    }

 
}
