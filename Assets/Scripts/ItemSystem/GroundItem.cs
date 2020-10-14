using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickUpable
{
    void PickUpItem();

}
public interface IInteractable
{
     void Interact(Matt_SM_PlayerStateInfo _owner);
}
public class GroundItem : MonoBehaviour, IInteractable
{

    [SerializeField] bool held = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
   public void Interact(Matt_SM_PlayerStateInfo _owner)
    {
        if(held == false) 
        {
            
            Matt_CharacterEquipment _charEquip = _owner.GetComponent<Matt_CharacterEquipment>();
            if (_charEquip.CheckIfItemHeld() == false) {
            held = true;
                Debug.Log("trying to equip");
            _charEquip.EquipItem(this);
            }
            else
            {
                Debug.Log("Character is already holding something");
            }
        }
        else
        {
            Debug.Log("item is currently held");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
}
