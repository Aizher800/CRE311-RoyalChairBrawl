using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _InputTest.Entity.Scripts.Input.Monobehaviours;

public enum spawnPlayerNumber
{

    Player1,
    Player2,
    Player3,
    Player4
}
public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update

    public spawnPlayerNumber associatedPlayerNumber;
   public GameObject characterBase;
   public SpawnPoint[] spawnPoints;
    void Start()
    {
        spawnPoints = FindObjectsOfType<SpawnPoint>();
        StartSpawn();
    }


    void StartSpawn() {
    
 
        for (int i = 0; i < spawnPoints.Length; i++)
        {

            spawnPoints[i].SpawnCharacter(characterBase);  
        }
    }
}
