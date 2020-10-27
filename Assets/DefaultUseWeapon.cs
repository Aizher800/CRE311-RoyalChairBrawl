﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _InputTest.Entity.Scripts.Input.Monobehaviours;
using Matt_HitBoxSystem;

namespace Matt_ItemSystem
{
    public class DefaultUseWeapon : Weapon
    {
     

        // Start is called before the first frame update
        public override void Use(Matt_SM_PlayerStateInfo _owner)
        {
            _thisOwner = _owner;
            attackOpen = true;
            _owner.PSI_animator.Play("mixamomelee2");
            Debug.Log("FIST ATTACK");
            StartCoroutine(HitReset());
        }
        private void OnTriggerEnter(Collider other)
        {

            Matt_HitBox hitbox = other.GetComponent<Matt_HitBox>();
            if (attackOpen)
            {
                if (hitbox._hitBoxOwner != _thisOwner)
                {
                    if (hitbox)
                    {
                        InvokeEvent(_thisOwner, hitbox._hitBoxOwner, (other.gameObject.transform.position - _thisOwner.gameObject.transform.position).normalized, _weaponDamage, 1f, hitbox._hitboxType);
                    
                        Debug.Log("fist hit delivered on " + hitbox._hitBoxOwner + "from " + _thisOwner.gameObject);
                        attackOpen = false;
                    }
                }
                else
                {
                    Debug.Log("hit yourself");
                }
            }
        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}
