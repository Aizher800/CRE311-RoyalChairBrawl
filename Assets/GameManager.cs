using UnityEngine;

public class GameManager : MonoBehaviour
{


    //public List<GameObject> spawnPoints = new List<GameObject>();
    [SerializeField] private GameObject[] spawnsArray = new GameObject[4];
    [SerializeField] private GameObject[] characterChoice = new GameObject[4];

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
        spawnsArray = GameObject.FindGameObjectsWithTag("Spawnpoint");


    }
    void SpawnCharacters()
    {
        for (int i = 0; i < spawnsArray.Length; i++)
        {
            if (spawnsArray[i] != null && characterChoice[i] != null)
            {
                Debug.Log("Spawned " + characterChoice[i] + "!");
                var spawnedChar = Instantiate(characterChoice[i], spawnsArray[i].transform.position, Quaternion.identity);
                AssignCharacters(spawnedChar);
            }


        }

    }

    void AssignCharacters(GameObject _spawnedChar)
    {

    }
}
