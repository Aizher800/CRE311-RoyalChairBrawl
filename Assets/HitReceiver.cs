using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Matt_ItemSystem;
namespace Matt_HitBoxSystem
{


public enum hitBoxType
{
    UPPER_BODY,
    LOWER_BODY,
    BLOCKING
}

public class HitReceiver : MonoBehaviour
{
    public delegate void HitReceiverEvent(Matt_SM_PlayerStateInfo _deliverer, Matt_SM_PlayerStateInfo _receiver, Vector3 direction, int damage, float forceMultiplier, hitBoxType type);
    public static event HitReceiverEvent OnHitReceived;


    Coroutine _knockbackCoroutine;
    public bool knockedBack = false;
  [SerializeField]  Matt_SM_PlayerStateInfo thisOwner;
    // Start is called before the first frame update
    void Start()
    {
        thisOwner = gameObject.GetComponentInParent<Matt_SM_PlayerStateInfo>();
        Weapon.OnHitDelivery += ReceiveHit;
    }


    void ReceiveHit(Matt_SM_PlayerStateInfo _deliverer, Matt_SM_PlayerStateInfo _receiver, Vector3 direction, int damage, float forceMultiplier, hitBoxType _type)
    {
       if (_receiver == thisOwner)
        {
          if(thisOwner.PSI_isBlocking == false) 
          { 
                    if (_knockbackCoroutine == null)
                    {
                            knockedBack = true;
                            Debug.Log("received hit to hitbox of type: " + _type);
                        thisOwner.playerHealth.RemoveHealth(1);
                        _knockbackCoroutine = thisOwner.StartCoroutine(HitKnockback(thisOwner, forceMultiplier, direction));
                    }
          }
         else
         {
                    thisOwner.PSI_animator.Play("mixamo_block");
         }
       }

    }
    // Update is called once per frame
    IEnumerator HitKnockback(Matt_SM_PlayerStateInfo _owner, float forceMultiply, Vector3 _direction)
    {


        while (_owner.PSI_jumpVelocity < forceMultiply * 0.9f)
        {
            _owner.PSI_jumpVelocity = Mathf.Lerp(_owner.PSI_jumpVelocity, forceMultiply, .1f);
            yield return null;
            _owner.PSI_characterController.Move(new Vector3(_direction.x, forceMultiply - _owner.PSI_jumpVelocity, _direction.z));
        }

        yield return new WaitUntil(() => (_owner.PSI_Grounded == false));
        {
          
        }


        yield return new WaitUntil(() => (_owner.PSI_Grounded == true));
        {
            //Debug.Log("landed");
            _owner.PSI_jumpVelocity = 0f;
          
            _knockbackCoroutine = null;
            yield return null;
        }
            knockedBack = false;
        _knockbackCoroutine = null;
        yield return null;
        Debug.Log("Knockback complete");

    }

        private void OnCollisionEnter(Collision collision)
        {
            if (knockedBack == true)
            {
              //  RaycastHit hit
           // if (Physics.Raycast(thisOwner.transform.position))
                Debug.Log("HIT AGAINST A WAAAALLL");
            // _knockbackCoroutine = thisOwner.StartCoroutine( HitKnockback(thisOwner, 1f, -collision.contacts[0].normal * 1f));
                Debug.DrawLine(thisOwner.transform.position, -collision.contacts[0].normal);
            }
        }
    }
}