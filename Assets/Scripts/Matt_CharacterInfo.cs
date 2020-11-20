using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Royal Chair Brawl", menuName = "CharacterDefinition ", order = 1)]
[System.Serializable]
public class Matt_CharacterInfo : ScriptableObject
{

    private string _ogName;
    private float _ogSpeed;
    private float _ogJump;
    private float _ogGrav;
    private float _ogAttack;

    void OnEnable()
    {
        _ogName = characterName;
        _ogSpeed = speedMultiplier;
        _ogJump = jumpMultiplier;
        _ogGrav = gravityMultiplier;
        _ogAttack = attackMultiplier;

    }

    
  
    public string characterName;
   [SerializeField] public float speedMultiplier;
    public float jumpMultiplier;
    public float gravityMultiplier;
    public float attackMultiplier;

    public GameObject characterVisual;
    public Avatar characterAvatar;
    public bool testBool;

}
