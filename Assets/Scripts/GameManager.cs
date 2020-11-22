using UnityEngine;
using _InputTest.Entity.Scripts.Input.Monobehaviours;
using Matt_HitBoxSystem;
public class GameManager : MonoBehaviour
{
    
    public static GameManager _mainInstance;
    public HealthContainerPanel containerPanel;

    //public List<GameObject> spawnPoints = new List<GameObject>();
    [SerializeField] private GameObject[] spawnsArray = new GameObject[4];
    [SerializeField] PlayerInputNum[] inputChoices = new PlayerInputNum[4];
    [SerializeField] private Matt_CharacterInfo[] characterChoice = new Matt_CharacterInfo[4];
    [SerializeField] GameObject characterPrefab;
    [SerializeField] GameObject healthPrefabBackup;


    //  private GameObject[] tempList = new GameObject[4];
    // Start is called before the first frame update
    void Start()
    {

        if (_mainInstance == null)
        {
            _mainInstance = this;
        }
        FindSpawns();
        SpawnCharacters();
        Time.timeScale = 1f;

    }

    // Update is called once per frame
    void Update()
    {

    }
   public void FindSpawns()
    {
        spawnsArray = GameObject.FindGameObjectsWithTag("SpawnPoint");


    }
 

    public void RespawnCharacter(GameObject _killedChar)
    {

        for (int i = 0; i < 1; i++)
        {
            FindSpawns();
            _killedChar.transform.position = spawnsArray[0].transform.position;
        }
      

    }
   public void SpawnCharacters()
    {
        FindSpawns();
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
                var healthInstance = Instantiate(healthPrefabBackup, containerPanel.transform);
                Erin_UI_PlayerHealth health = spawnedChar.GetComponent<Erin_UI_PlayerHealth>();
                health.characterHealth = healthInstance.GetComponent<HealthBarScript>();
                healthInstance.GetComponent<HealthBarScript>().charText = characterChoice[i].characterName;
                spawnedChar.GetComponent<PlayerScore>().associatedHealth = healthInstance.GetComponent<HealthBarScript>();
                health.characterHealth.playerNum = inputChoices[i];
                health.associatedPlayerNum = inputChoices[i];
                health.OnSpawn();
                health.characterHealth.OnLoad();

            }


        }

    }


}
