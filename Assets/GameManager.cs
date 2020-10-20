using UnityEngine;
using _InputTest.Entity.Scripts.Input.Monobehaviours;
public class GameManager : MonoBehaviour
{


    //public List<GameObject> spawnPoints = new List<GameObject>();
    [SerializeField] private GameObject[] spawnsArray;
    [SerializeField] PlayerInputNum[] inputChoices;
    [SerializeField] private Matt_CharacterInfo[] characterChoice;
    [SerializeField] GameObject characterPrefab;

    Matt_CameraGroupManager camComposerManager;

    //  private GameObject[] tempList = new GameObject[4];
    // Start is called before the first frame update
    void Start()
    {
        camComposerManager = FindObjectOfType<Matt_CameraGroupManager>();
        FindSpawns();
        SpawnCharacters();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FindSpawns()
    {
        for (int i = 0; i < spawnsArray.Length; i++)
        {
            spawnsArray[i] = GameObject.FindGameObjectsWithTag("SpawnPoint")[i];
        }
       


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
                charInput.playerInput = inputChoices[i];
                charInput.SetInput();
                spawnedChar.GetComponent<Matt_SM_PlayerStateInfo>().LoadCharacterInfo(characterChoice[i]);
                
            }


        }
        camComposerManager.FindTargets();

        

    }


}
