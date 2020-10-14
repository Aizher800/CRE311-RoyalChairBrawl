using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _InputTest.Entity.Scripts.Input.Monobehaviours;
using TSC_INPUT_SYSTEM;
public class InteractCollider : MonoBehaviour
{
    // Start is called before the first frame update

    AbstractInput _input;
    public IInteractable targetObject;

    private void Start()
    {
        //_input = GetComponentInParent<AbstractInput>();
       // _input.OnInteractEvent += InteractWithSomething;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IInteractable>() != null)
        {
            Debug.Log(other + " is an interactable!");
            targetObject = other.GetComponent<IInteractable>();
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<IInteractable>() != null)
        {
            Debug.Log(other + " has left radius.");
            targetObject = null;
        }

    }

    void InteractWithSomething(Matt_SM_PlayerStateInfo _owner)
    {
        if (targetObject != null)
        {
            targetObject.Interact(_owner);
        }
      
    }
}
