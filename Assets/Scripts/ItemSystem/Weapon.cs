﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _InputTest.Entity.Scripts.Input.Monobehaviours;

namespace Matt_ItemSystem { 
public class Weapon : HeldItem
{
   GroundItem groundRef;

    int _weaponDamage;
    [SerializeField] string _weaponName;

        public override void Use()
        {
            Debug.Log("WEAPON ATTACK");
        }
    }


    public class MeleeWeapon : Weapon
    {




    }

    public class HeldItem : MonoBehaviour
    {

        public virtual void Use()
        {

            Debug.Log("Used default heldItem");
        }

    }
}