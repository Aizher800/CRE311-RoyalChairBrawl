using UnityEngine;
using _InputTest.Entity.Scripts.Input.Monobehaviours;
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
    //  private GameObject[] tempList = new GameObject[4];
    // Start is called before the first frame update
    void Start()
    {
        FindSpawns();
        SpawnCharacters();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FindSpawns()
    {
        spawnsArray = GameObject.FindGameObjectsWithTag("SpawnPoint");


    }
    void SpawnCharacters()
    {
        for (int i = 0; i < spawnsArray.Length; i++)
        {
            if (spawnsArray[i] != null && characterChoice[i] != null)
            {
                Debug.Log("Spawned " + characterChoice[i] + "!");
                var spawnedChar = Instantiate(characterPrefab, spawnsArray[i].transform.position, Quaternion.identity);
                var charInput = spawnedChar.GetComponent<CharacterInput>();
                spawnedChar.GetComponent<Matt_SM_PlayerStateInfo>().LoadCharacterInfo(characterChoice[i]);

                charInput.playerInput = inputChoices[i];
                charInput.SetInput();
                var charHealth = spawnedChar.GetComponent<Erin_UI_PlayerHealth>();

                if (charHealth != null)
                {
                    Debug.Log("setting char health for " + i);
                }
               charHealth.associatedPlayerNum = inputChoices[i];
                charHealth.healthPrefab = healthPrefabBackup;
               charHealth.OnSpawn();

             
                
            }


        }

    }


}
