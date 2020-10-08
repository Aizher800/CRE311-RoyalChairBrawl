﻿using _InputTest.Entity.Scripts.Input.Monobehaviours;
using Matt_StateSystem;
using UnityEngine;

public class Matt_SM_PlayerStateInfo : MonoBehaviour
{
    [SerializeField] public int state;
    public Vector3 navObjective;
    // public int specialAnimNumber;

    public AbstractInput PSI_inputSource;
   [SerializeField] public Vector3 PSI_Velocity;
   public CharacterController PSI_characterController;
    [SerializeField] public bool PSI_Grounded;
    public bool weaponReady = false;
    public bool lockedOn = false;
    Animator anim;
  

    public State<Matt_SM_PlayerStateInfo> scheduledState = null;
    public bool switchState = false;
    public float gameTimer;
    public int seconds = 0;


    private Matt_SM_StateMachine<Matt_SM_PlayerStateInfo> stateMachine { get; set; }

    private void Start()
    {
        PSI_characterController = GetComponent<CharacterController>();

        PSI_inputSource = GetComponent<AbstractInput>();
        PSI_Velocity = Vector3.zero;

        anim = gameObject.GetComponent<Animator>();
        stateMachine = new Matt_SM_StateMachine<Matt_SM_PlayerStateInfo>(this);
        //stateMachine.ChangeState(FirstState.Instance);
        gameTimer = Time.time;
        stateMachine.ChangeState(new Matt_SM_FreeMoveState());
    }

    private void Update()
    {

        PSI_Grounded = GetComponent<CharacterController>().isGrounded;
        state = GetStateMachineStateNumber();
        stateMachine.Update();


    }

    public int GetStateMachineStateNumber()
    {
        return (stateMachine.GetStateNumber());
    }



    public bool IsPreviousStateRestorableState()
    {
        if (stateMachine.previousState.restorableState == true)
        {
            Debug.Log("its totally restoradable");
            return true;
        }
        if (stateMachine.previousState.restorableState == false)
        {
            Debug.Log("its NOT restorable");

            return false;
        }
        else
        {
            Debug.Log("playerstateinfo restore state check catch error.");
            return false;
        }


    }
    public void ChangeStateMachineState(State<Matt_SM_PlayerStateInfo> _newstate)

    {
        stateMachine.ChangeState(_newstate);

    }
    public void RestoreStateMachineState()
    {
        stateMachine.RestoreState();

    }

}
