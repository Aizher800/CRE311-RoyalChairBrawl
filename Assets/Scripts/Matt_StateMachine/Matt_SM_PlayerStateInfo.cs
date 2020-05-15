using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Matt_StateSystem;
using UnityEngine.UI;

//NOT FINISHED
public class Matt_SM_PlayerStateInfo : MonoBehaviour
{
    [SerializeField] public int state;
    public Vector3 navObjective;
    // public int specialAnimNumber;
   

    public bool weaponReady = false;
    public bool lockedOn = false;
    Animator anim;
    [SerializeField] Text lastState;
    [SerializeField] Text currentState;

    public State<Matt_SM_PlayerStateInfo> scheduledState = null;
    public bool switchState = false;
    public float gameTimer;
    public int seconds = 0;

    private Matt_SM_StateMachine<Matt_SM_PlayerStateInfo> stateMachine { get; set; }

    private void Start()
    {
        
        anim = gameObject.GetComponent<Animator>();
        stateMachine = new Matt_SM_StateMachine<Matt_SM_PlayerStateInfo>(this);
        //stateMachine.ChangeState(FirstState.Instance);
        gameTimer = Time.time;
        stateMachine.ChangeState(Matt_SM_FreeMoveState.Instance);
    }

    private void Update()
    {
        state = GetStateMachineStateNumber();
        stateMachine.Update();

        if (stateMachine.currentState != null) { 
        currentState.text = stateMachine.currentState.ToString();
        }
        if (stateMachine.previousState != null)
        {
            lastState.text = stateMachine.previousState.ToString();
        }
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
    //  public void StartObjective()
    // {


    // }

    // public void StopObjective()
    //{


    //}

    /* public void SpecialAnim(int specialAnimNumber)
     {
         anim.SetInteger("specialAnim", specialAnimNumber);

     }
     public void EndSpecialAnim()
     {

         anim.SetInteger("specialAnim", 0);
     }
     */
}
