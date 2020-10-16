using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _InputTest.Entity.Scripts.Input.Monobehaviours;
using Matt_HitBoxSystem;

namespace Matt_ItemSystem { 
public class Weapon : HeldItem
{
   GroundItem groundRef;

        public delegate void HitDeliveryEvent(Matt_SM_PlayerStateInfo _deliverer, Matt_SM_PlayerStateInfo _receiver, Vector3 direction, float forceMultiplier, hitBoxType type);
        public static event HitDeliveryEvent OnHitDelivery;

        bool attackOpen = true;

        Matt_SM_PlayerStateInfo _thisOwner;
       [SerializeField] Material openMat;
        [SerializeField] Material closedMat;
        [SerializeField]  bool attackActive = false;
    int _weaponDamage;
    [SerializeField] string _weaponName;
        
        public override void Use(Matt_SM_PlayerStateInfo _owner)
        {
            _owner.PSI_animator.Play("mixamomelee2");
            Debug.Log("WEAPON ATTACK");
            _thisOwner = _owner;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other != this.gameObject)
            {
                Matt_HitBox hitbox = other.GetComponent<Matt_HitBox>();
                if (hitbox)
                {
                    OnHitDelivery?.Invoke(_thisOwner, hitbox._hitBoxOwner, Vector3.right, 1f, hitbox._hitboxType);
                    Debug.Log("Hit delivered");
                }
            }
            else
            {
                Debug.Log("hit yourself");
            }
        }
        public void WindowOpen()
        {
            gameObject.GetComponent<MeshRenderer>().material = openMat;
        }

        public void WindowClose()
        {
            gameObject.GetComponent<MeshRenderer>().material = closedMat;
        }
    }

 
    public class HeldItem : MonoBehaviour
    {

        public virtual void Use(Matt_SM_PlayerStateInfo _owner)
        {

            Debug.Log("Used default heldItem");
        }

        private void OnTriggerEnter(Collider other)
        {
            
        }
    }

}