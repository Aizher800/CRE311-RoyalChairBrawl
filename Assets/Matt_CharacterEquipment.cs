using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Matt_ItemSystem;
public class Matt_CharacterEquipment : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] bool holdingItem = false;
    [SerializeField] Weapon_Parent handPos;

    public bool CheckIfItemHeld()
    {

        return holdingItem;
    }
    void Start()
    {
        handPos = gameObject.GetComponentInChildren<Weapon_Parent>();
        if (handPos != null)
        {
            Debug.Log("handpos FOUND");
        }
        else
        {
            Debug.Log("no HANDPOS");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EquipItem(GroundItem _weapon)
    {
        _weapon.gameObject.transform.parent = handPos.gameObject.transform;
        _weapon.gameObject.transform.localPosition = Vector3.zero;
        Debug.Log("moved item to hand");
        holdingItem = true;
    }

    public void UnequipItem(GroundItem _weapon)
    {


    }
}
