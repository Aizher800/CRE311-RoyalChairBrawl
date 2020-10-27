using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IInteractable
{
     void Interact(Matt_SM_PlayerStateInfo _owner);
}
public class GroundItem : MonoBehaviour, IInteractable
{

    Rigidbody rb;
   
    [SerializeField] bool held = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
   public virtual void Interact(Matt_SM_PlayerStateInfo _owner)
    {
        if(held == false) 
        {
            
            Matt_CharacterEquipment _charEquip = _owner.GetComponent<Matt_CharacterEquipment>();
            if (_charEquip.CheckIfItemHeld() == false) {
            held = true;
                ItemSetHeldBehaviour();
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
   public void OnDrop()
    {
        held = false;
        ItemSetGroundBehaviour();

    }
    void ItemSetGroundBehaviour()
    {
        gameObject.layer = 9;
        rb.isKinematic = false;
        rb.useGravity = true;

    }
    void ItemSetHeldBehaviour()
    {
       gameObject.layer = 8;
        rb.isKinematic = true;
        rb.useGravity = false;
       

    }
    // Update is called once per frame
    void Update()
    {
        
    }

  
}
