using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _InputTest.Entity.Scripts.Input.Monobehaviours;
public class SpawnPoint : MonoBehaviour
{
    public PlayerInputNum associatedPlayerNumber;


    public void SpawnCharacter(GameObject _characterToSpawn)
    {
        GameObject spawnedChar = Instantiate(_characterToSpawn);
        spawnedChar.GetComponent<CharacterInput>().playerInput = associatedPlayerNumber;
        spawnedChar.transform.position = gameObject.transform.position;
        var psi = spawnedChar.GetComponent<Matt_SM_PlayerStateInfo>();
      //  psi.OnSpawn(_charInfo);
        

    }
}
