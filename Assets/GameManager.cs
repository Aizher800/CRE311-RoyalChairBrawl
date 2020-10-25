using UnityEngine;
using _InputTest.Entity.Scripts.Input.Monobehaviours;
using Matt_HitBoxSystem;
public class GameManager : MonoBehaviour
{

    public delegate void UpdateHealthEvent(PlayerInputNum num, int newHealth, int newEnergy);
    public static event UpdateHealthEvent OnHealthUpdate;
    //public List<GameObject> spawnPoints = new List<GameObject>();
    [SerializeField] private GameObject[] spawnsArray = new GameObject[4];
    [SerializeField] PlayerInputNum[] inputChoices = new PlayerInputNum[4];
    [SerializeField] private Matt_CharacterInfo[] characterChoice = new Matt_CharacterInfo[4];
    [SerializeField] GameObject characterPrefab;
    [SerializeField] GameObject healthPrefabBackup;

    //RIPPED FROM ERIN'S HEALTH SCRIPT
    public int maxHealth = 6;
    public int currentHealth = 6;

    [SerializeField] public GameObject healthPrefab;
    public HealthBarScript characterHealth;
    public HealthContainerPanel containerPanel;

    GameObject associatedUIObject;
    //  private GameObject[] tempList = new GameObject[4];
    // Start is called before the first frame update
    void Start()
    {
        FindSpawns();
        SpawnCharacters();
        HitReceiver.OnHealthChange += RemoveHealth;

    }

    // Update is called once per frame
    void Update()
    {

    }
    void FindSpawns()
    {
        spawnsArray = GameObject.FindGameObjectsWithTag("SpawnPoint");


    }
    public void OnSpawn()
    {

      
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
    void SpawnCharacters()
    {
        for (int i = 0; i < spawnsArray.Length; i++)
        {
            if (spawnsArray[i] != null && characterChoice[i] != null)
            {
                containerPanel = FindObjectOfType<HealthContainerPanel>();
                Debug.Log("Spawned " + characterChoice[i] + "!");
                var spawnedChar = Instantiate(characterPrefab, spawnsArray[i].transform.position, Quaternion.identity);
                var charInput = spawnedChar.GetComponent<CharacterInput>();
                spawnedChar.GetComponent<Matt_SM_PlayerStateInfo>().LoadCharacterInfo(characterChoice[i]);

                charInput.playerInput = inputChoices[i];
                charInput.SetInput();
                var healthInstance = Instantiate(healthPrefab, containerPanel.transform);

                characterHealth = healthInstance.GetComponent<HealthBarScript>();
                characterHealth.playerNum = inputChoices[i];

            }


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
        currentHealth = currentHealth + amount;
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


        //  healthBar.SetHealth(currentHealth); //Adjusting health bar according to health.
    }

}
