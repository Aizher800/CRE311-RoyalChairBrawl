
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TSC_INPUT_SYSTEM;

using UnityEngine.InputSystem;
using _InputTest.Entity.Scripts.Input;
using _InputTest.Entity.Scripts.Input.Monobehaviours;


public class Matt_BlockCommand : Matt_StateSystem.Command<Matt_SM_PlayerStateInfo>
{

    override public void EnableCommand(Matt_SM_PlayerStateInfo _owner)
    {
        _owner.PSI_inputSource.OnBlockHoldEvent += Block;
        _owner.PSI_inputSource.OnBlockReleaseEvent += ReleaseBlock;
    }

    void Block(Matt_SM_PlayerStateInfo _owner, bool trueFalse)
    {
        Debug.Log("button returned" + trueFalse);
        if (trueFalse == true && _owner.PSI_isMoving == false) {
        

            _owner.PSI_isBlocking = true;
          
            
            _owner.PSI_animator.SetBool("Blocking", true);
            _owner.PSI_animator.Play("mixamo_blockidle");
            Debug.Log("Blocked");
        }
        else
        {
            _owner.PSI_isBlocking = false;
          
            _owner.PSI_animator.SetBool("Blocking", false);
            Debug.Log("released block");

        }
       
        
    

    }

    void ReleaseBlock(Matt_SM_PlayerStateInfo _owner)
    {
        _owner.PSI_isBlocking = false;
        _owner.PSI_animator.SetBool("Blocking", false);
        Debug.Log("released block");

    }
    public override void RunCommand(Matt_SM_PlayerStateInfo _owner, Vector2 value)
    {
        Debug.Log("block update");
    }
}
