using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Matt_HitBoxSystem { 



public class Matt_HitBox : MonoBehaviour
{

        public Matt_SM_PlayerStateInfo  _hitBoxOwner;


        public hitBoxType _hitboxType;
       
        // Start is called before the first frame update
        void Start()
    {
            _hitBoxOwner = GetComponentInParent<Matt_SM_PlayerStateInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hitbox hit of type " + _hitboxType + "!");
    }
}
}