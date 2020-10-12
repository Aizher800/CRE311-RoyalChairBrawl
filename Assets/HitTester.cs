using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Matt_HitBoxSystem {
public class HitTester : MonoBehaviour
{
    // Start is called before the first frame update
    public bool canHit = true;

        public delegate void HitDeliveryEvent(Matt_SM_PlayerStateInfo _deliverer, Matt_SM_PlayerStateInfo _receiver, Vector3 direction, float forceMultiplier, hitBoxType type);
        public static event HitDeliveryEvent OnHitDelivery;
    private void OnTriggerEnter(Collider other)
    {
        if (canHit)
        {
                Matt_HitBox hitbox = other.GetComponent<Matt_HitBox>();
                if (hitbox)
                {
                    OnHitDelivery?.Invoke(new Matt_SM_PlayerStateInfo(), hitbox._hitBoxOwner, Vector3.right, 1f, hitbox._hitboxType);
                    Debug.Log("Hit delivered");
                }
               
           
        }
    }
}
}
