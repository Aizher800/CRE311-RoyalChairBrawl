using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _InputTest.Entity.Scripts.Input.Monobehaviours;
using TSC_INPUT_SYSTEM;
public class InteractCollider : MonoBehaviour
{
    // Start is called before the first frame update

    AbstractInput _input;
    private void Start()
    {
        _input = GetComponentInParent<AbstractInput>();
        _input.OnInteractEvent += InteractWithSomething;
    }
    private void OnTriggerStay(Collider other)
    {
        
        
    }

    void InteractWithSomething(Matt_SM_PlayerStateInfo _owner)
    {
        Debug.Log("interacted with something");
    }
}
