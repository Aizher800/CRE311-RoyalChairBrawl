using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Matt_StateSystem;

public class Matt_GravityCommand : Command<Matt_SM_PlayerStateInfo>
{
   
    private Matt_SM_PlayerStateInfo stateInfo;
    private CharacterController controller;


    
    float velocityDamp = 14f; //velocityDamp is the rate at which the forces applied to the player revert to their original values
   //basically all the gravity-based stuff affecting the player, velocity is added on top of the player movement vector3
    float gravity = -15f;

    private Coroutine _physicsCoroutine;
    override public void EnableCommand(Matt_SM_PlayerStateInfo _owner)
    {
        
        Debug.Log("Gravity Command Enabled");
        commandOwner = _owner.gameObject;
        //anim = enableOwner.GetComponent<Animator>();
        
     _owner.GetComponent<Animator>().applyRootMotion = false;
        //stateInfo = commandOwner.GetComponent<PlayerStateInfo>();
    
        controller = _owner.GetComponent<CharacterController>();
       // commandId = stateInfo.PSI_uniqueId;

     
    }

    // public override void Execute(string id, Vector2 value)
    // {
    // if (commandId == id)
    //{


    //}
    //  else
    // {
    //   Debug.Log("Gravity Command denied, command was for" + commandId + ", but i wanted " + id);
    //  }
    // }
    override public void RunCommand(Matt_SM_PlayerStateInfo _owner, Vector2 value)
    {
        if (_physicsCoroutine == null)
        {
            _physicsCoroutine = commandOwner.GetComponent<Matt_SM_PlayerStateInfo>().StartCoroutine(CharacterPhysics(_owner));
        }
    }
    

    IEnumerator CharacterPhysics(Matt_SM_PlayerStateInfo _owner)//this handles all the gravitational stuff affecting player, also jumping just adds a big burst of upwards momentum to the player
    {
        while (_owner.GetComponent<CharacterController>().isGrounded == false)
        {
            Debug.Log("GRAVITYGRA");
            _owner.PSI_Velocity = Vector3.Lerp(_owner.PSI_Velocity, new Vector3(0, gravity, 0), velocityDamp * Time.deltaTime);
            _owner.GetComponent<CharacterController>().Move(_owner.PSI_Velocity * Time.deltaTime);
            yield return null;
        }

        yield return null;
        _physicsCoroutine = null;
    }
    override public void EndCommand(Matt_SM_PlayerStateInfo _owner)
    {
      //  velocity = Vector3.zero;
        _physicsCoroutine = null;
    }
}
