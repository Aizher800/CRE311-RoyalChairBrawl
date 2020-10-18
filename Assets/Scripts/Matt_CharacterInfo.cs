using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Royal Chair Brawl", menuName = "CharacterDefinition ", order = 1)]
public class Matt_CharacterInfo : ScriptableObject
{
    public string characterName;
   [SerializeField] public float speedMultiplier;
    public float jumpMultiplier;
    public float gravityMultiplier;
    public float attackMultiplier;

    public GameObject characterVisual;
    public Avatar characterAvatar;
    public bool testBool;

}
