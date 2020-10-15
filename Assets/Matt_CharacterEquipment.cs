﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Matt_ItemSystem;
using _InputTest.Entity.Scripts.Input.Monobehaviours;
public class Matt_CharacterEquipment : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] bool holdingItem = false;
    [SerializeField] Weapon_Parent handPos;
   [SerializeField] GroundItem currentItem;
   [SerializeField] HeldItem currentHeldItem;
    [SerializeField] HeldItem defaultWeapon;

    AbstractInput _input;
    Matt_SM_PlayerStateInfo thisOwner;

    InteractCollider interactCollider;
    [SerializeField] bool canUnequip = false;
    [SerializeField] bool canEquip = true;
    public bool CheckIfItemHeld()
    {

        return holdingItem;
    }
    void Start()
    {
        thisOwner = GetComponent<Matt_SM_PlayerStateInfo>();
        interactCollider = GetComponentInChildren<InteractCollider>();
        _input = GetComponent<AbstractInput>();
      
        handPos = gameObject.GetComponentInChildren<Weapon_Parent>();
        if (handPos != null)
        {
            defaultWeapon = handPos.GetComponent<DefaultUseWeapon>();
            Debug.Log("handpos FOUND");
        }
        else
        {
            Debug.Log("no HANDPOS");
        }
        _input.OnFireInputEvent += UseHeldItem;
        _input.OnInteractEvent += UnequipItem;
        _input.OnInteractEvent += InteractWithSomething;
    }

    void UseHeldItem(Matt_SM_PlayerStateInfo _owner)
    {
        if (_owner.CheckAttackLock()) { return;  }
        Debug.Log("use item triggered");
        if (holdingItem)
        {

            if (currentHeldItem != null)
            {
                Debug.Log("yoyoyo oyo ooyo oy ooy oy oyoyoo used ITEM");
                currentHeldItem.Use();
            }
         
        }
        else
        {

            defaultWeapon.Use();
        }
    }
    void InteractWithSomething(Matt_SM_PlayerStateInfo _owner)
    {
        if (_owner.CheckAttackLock()) { return; }
        if (canEquip == true) { 
            if (interactCollider.targetObject != null)
            {
                interactCollider.targetObject.Interact(_owner);
            }
        }
    }
    IEnumerator AllowUnequipBoolTimer()
    {
        canUnequip = false;
        Debug.Log("bool is locked");
        yield return new WaitForSeconds(2);
        canUnequip = true;
        Debug.Log("bool has been unlocked");
        yield return canUnequip;
    }

    IEnumerator AllowEquipBoolTimer()
    {
        canEquip = false;
        Debug.Log("bool is locked");
        yield return new WaitForSeconds(2);
        canEquip = true;
        Debug.Log("bool has been unlocked");
        yield return canEquip;
    }
    public void EquipItem(GroundItem _weapon)
    {
        if(holdingItem == false) {
          canEquip = false;
        currentItem = _weapon;
        currentItem.gameObject.transform.parent = handPos.gameObject.transform;
        currentItem.gameObject.transform.localPosition = Vector3.zero;
            currentHeldItem = currentItem.GetComponent<HeldItem>();
        Debug.Log("moved item to hand");
            StartCoroutine(AllowUnequipBoolTimer());
            holdingItem = true;
        }
    }
  
    public void UnequipItem(Matt_SM_PlayerStateInfo _owner)
    {
        if (canUnequip == false)
        {
            Debug.Log("cant unequip yet");
            return;
        }
        if (currentItem != null) {
            if (CheckIfItemHeld() == true)
            {
                Debug.Log("DROPDROP");
               currentItem.transform.parent = null;
                currentItem.transform.position = gameObject.transform.position;
                currentItem.OnDrop();
                holdingItem = false;
                StartCoroutine(AllowEquipBoolTimer());
            }
        }
        else
        {
            Debug.Log("no current item");
        }
    }
}