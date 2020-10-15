using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _InputTest.Entity.Scripts.Input.Monobehaviours;
namespace Matt_ItemSystem
{
    public class DefaultUseWeapon : HeldItem
    {
        // Start is called before the first frame update
        public override void Use()
        {
            Debug.Log("FIST ATTACK");
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
