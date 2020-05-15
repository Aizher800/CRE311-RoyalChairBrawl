using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Matt_StateSystem;



public class Matt_SM_AttackState : State<Matt_SM_PlayerStateInfo>
{
    private static Matt_SM_AttackState _instance;
    //AttackTest attackTest; The Attack Script 
    Vector3 playerTransform;
    private Matt_SM_AttackState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }


    public static Matt_SM_AttackState Instance
    {
        get
        {
            if (_instance == null)
            {
                new Matt_SM_AttackState();
                Instance.stateNumber = 3;
                Instance.restorableState = false;
            }

            return _instance;
        }
    }

    public override void EnterState(Matt_SM_PlayerStateInfo _owner)
    {
        
        //  Debug.Log("Entering THIRD State");
       // attackTest = _owner.GetComponent<AttackTest>();
        //attackTest.Attack(); THIS WILL BE THE SCrIPT THAT HANDLES ATTACKING
        _owner.state = 3;

    }

    public override void ExitState(Matt_SM_PlayerStateInfo _owner)
    {
        
        //Debug.Log("Exiting THIRD State");
    }

    public override void UpdateState(Matt_SM_PlayerStateInfo _owner)
    {
        //if (!_owner.switchState)
        // {
        //   _owner.stateMachine.ChangeState(FirstState.Instance);
        // }
    }
}
