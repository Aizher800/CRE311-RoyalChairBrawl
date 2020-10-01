using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Matt_StateSystem;


public class Matt_SM_FreeMoveState : State<Matt_SM_PlayerStateInfo>
{
    //NOT FINISHED

    private static Matt_SM_FreeMoveState _instance;
   
    private Matt_SM_FreeMoveState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }


    public static Matt_SM_FreeMoveState Instance
    {
        get
        {
            if (_instance == null)
            {
                new Matt_SM_FreeMoveState();
                Instance.stateNumber = 1;
                Instance.restorableState = true;
            }

            return _instance;
        }
    }

    public override void EnterState(Matt_SM_PlayerStateInfo _owner)
    {
        commands[0] = new Matt_MovementCommand();
        commands[1] = new Matt_GravityCommand();
        //playerTransform = GameObject.FindObjectOfType<PlayerMovementController>().gameObject.transform.position;
        //  Debug.Log("Entering THIRD State");
        //playerStateInfo = _owner.GetComponent<PlayerStateInfo>();
        _owner.state = 1;

        EnableCommands(_owner);
        Debug.Log("Enablign Commands");


    }

    public override void ExitState(Matt_SM_PlayerStateInfo _owner)
    {

        //Debug.Log("Exiting THIRD State");
    }

    public override void UpdateState(Matt_SM_PlayerStateInfo _owner)
    {

      //  Debug.Log("FREEMOVEUPDATE");
       // if (Input.GetButtonUp("AttackButton"))
       // {
          //  if (_owner.weaponReady == true) { 
          //  _owner.ChangeStateMachineState(Matt_SM_AttackState.Instance);
        //   }
      //  }
        for (int i = 0; i < commands.Length; i++)
        {
            if(commands[i] != null)
            {
                Debug.Log("command update for " + commands[i]);
                //commands[i].RunCommand(_owner);
                //if (!_owner.switchState)
                // {
                //   _owner.stateMachine.ChangeState(FirstState.Instance);
                // }

            }

             
            
        }

        //if (!_owner.switchState)
        // {
        //   _owner.stateMachine.ChangeState(FirstState.Instance);
        // }
    }

}

