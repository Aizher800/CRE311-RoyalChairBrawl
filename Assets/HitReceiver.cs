﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    public delegate void HitReceiverEvent(Matt_SM_PlayerStateInfo _deliverer, Matt_SM_PlayerStateInfo _receiver, Vector3 direction, float forceMultiplier, hitBoxType type);
    public static event HitReceiverEvent OnHitReceived;

    Coroutine _knockbackCoroutine;

  [SerializeField]  Matt_SM_PlayerStateInfo thisOwner;
    // Start is called before the first frame update
    void Start()
    {
        thisOwner = gameObject.GetComponentInParent<Matt_SM_PlayerStateInfo>();
        HitTester.OnHitDelivery += ReceiveHit;
    }


    void ReceiveHit(Matt_SM_PlayerStateInfo _deliverer, Matt_SM_PlayerStateInfo _receiver, Vector3 direction, float forceMultiplier, hitBoxType _type)
    {
       if (_receiver == thisOwner)
        {
            if (_knockbackCoroutine == null)
            {
                    Debug.Log("received hit to hitbox of type: " + _type);
                _knockbackCoroutine = thisOwner.StartCoroutine(HitKnockback(thisOwner, forceMultiplier));
            }
        }

    }
    // Update is called once per frame
    IEnumerator HitKnockback(Matt_SM_PlayerStateInfo _owner, float forceMultiply)
    {


        while (_owner.PSI_jumpVelocity < forceMultiply * 0.9f)
        {
            _owner.PSI_jumpVelocity = Mathf.Lerp(_owner.PSI_jumpVelocity, forceMultiply, .1f);
            yield return null;
            _owner.PSI_characterController.Move(new Vector3(0, forceMultiply - _owner.PSI_jumpVelocity, 0));
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
        _knockbackCoroutine = null;
        yield return null;
        Debug.Log("finished JUmp");

    }
}
}