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

       [SerializeField] protected bool attackOpen = true;

     [SerializeField] public  Matt_SM_PlayerStateInfo _thisOwner;
       [SerializeField] Material openMat;
        [SerializeField] Material closedMat;
        [SerializeField]  bool attackActive = false;
   [SerializeField] protected int _weaponDamage;
      //  [SerializeField] protected int _heavyDamage;
    [SerializeField] string _weaponName;
        public string lightAttackAnimName = "mixamomelee2";
        public string heavyAttackAnimName = "mixamomelee1";
        float startingZPos = 0f;
        public override void Use(Matt_SM_PlayerStateInfo _owner)
        {
            attackOpen = true;
            _owner.PSI_animator.Play(lightAttackAnimName);
            Debug.Log("WEAPON ATTACK");
            _thisOwner = _owner;
            StartCoroutine(HitReset());
        }

        public override void HeavyUse(Matt_SM_PlayerStateInfo _owner)
        {
            startingZPos = _owner.transform.position.z;
       
            if (_owner.GetComponent<Erin_UI_PlayerHealth>().currentEnergy > 0)
            {
                _owner.PSI_Velocity = new Vector3(_owner.gameObject.transform.forward.x, _owner.gameObject.transform.forward.y, 0);
                _owner.GetComponent<Erin_UI_PlayerHealth>().RemoveEnergy(-1, _owner.PSI_inputNum);

                attackOpen = true;
                _owner.PSI_animator.Play(heavyAttackAnimName);
                Debug.Log("WEAPON ATTACK");
                _thisOwner = _owner;
                StartCoroutine(HitReset());
            }
         
        }
        public void InvokeEvent(Matt_SM_PlayerStateInfo _deliverer, Matt_SM_PlayerStateInfo _receiver, Vector3 direction, int damage, float forceMultiplier, hitBoxType type)
        {
           OnHitDelivery?.Invoke(_deliverer, _receiver, direction,damage, forceMultiplier, type);

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
 

       public  IEnumerator HitReset()
        {

            yield return new WaitForSeconds(1);
            attackOpen = false;
            yield return null;
        }
    }

    
    public class HeldItem : MonoBehaviour
    {
        public bool isChair = false;
        public virtual void Use(Matt_SM_PlayerStateInfo _owner)
        {

            Debug.Log("Used default heldItem");
        }

        public virtual void HeavyUse(Matt_SM_PlayerStateInfo _owner)
        {
            Debug.Log("Used heavy heldItem");
        }

        private void OnTriggerEnter(Collider other)
        {
            
        }
    }

}