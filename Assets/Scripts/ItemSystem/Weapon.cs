using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _InputTest.Entity.Scripts.Input.Monobehaviours;
using Matt_HitBoxSystem;

namespace Matt_ItemSystem { 
public class Weapon : HeldItem
{
   GroundItem groundRef;

        public delegate void HitDeliveryEvent(Matt_SM_PlayerStateInfo _deliverer, Matt_SM_PlayerStateInfo _receiver, Vector3 direction, int damage, float forceMultiplier, hitBoxType type);
        public static event HitDeliveryEvent OnHitDelivery;

       [SerializeField] bool attackOpen = true;

     [SerializeField]   Matt_SM_PlayerStateInfo _thisOwner;
       [SerializeField] Material openMat;
        [SerializeField] Material closedMat;
        [SerializeField]  bool attackActive = false;
   [SerializeField] int _weaponDamage;
    [SerializeField] string _weaponName;
        
        public override void Use(Matt_SM_PlayerStateInfo _owner)
        {
            attackOpen = true;
            _owner.PSI_animator.Play("mixamomelee2");
            Debug.Log("WEAPON ATTACK");
            _thisOwner = _owner;
        }

        private void OnTriggerEnter(Collider other)
        {
          
            Matt_HitBox hitbox = other.GetComponent<Matt_HitBox>();
            if (attackOpen) { 
                if (hitbox._hitBoxOwner != _thisOwner)
                {
                    if (hitbox)
                    {
                        OnHitDelivery?.Invoke(_thisOwner, hitbox._hitBoxOwner, (other.gameObject.transform.position - _thisOwner.gameObject.transform.position).normalized, _weaponDamage, 1f, hitbox._hitboxType);
                        Debug.Log("Hit delivered on " + hitbox._hitBoxOwner + "from " + _thisOwner.gameObject);
                        attackOpen = false;
                    }
                }
                else
                {
                    Debug.Log("hit yourself");
                }
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