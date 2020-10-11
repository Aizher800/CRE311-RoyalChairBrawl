using _InputTest.Entity.Scripts.Input.Monobehaviours;
using Matt_StateSystem;
using UnityEngine;

public class Matt_SM_PlayerStateInfo : MonoBehaviour
{
    [SerializeField] public int state;
    public Vector3 navObjective;
    // public int specialAnimNumber;

    public AbstractInput PSI_inputSource;
    public Vector3 PSI_Velocity { get; }
    public float PSI_jumpVelocity { get; set; }
   public CharacterController PSI_characterController;
    [SerializeField] public bool PSI_Grounded;
    public bool weaponReady = false;
    public bool lockedOn = false;
    Animator anim;

    [SerializeField] bool PSI_movementLock;
    [SerializeField] bool PSI_gravityLock;
    [SerializeField] bool PSI_attackLock;

    [SerializeField] public bool jumpVelocitySet = false;

   [SerializeField] Vector3 lastPos;
    Vector3 currentPos;
   public float pSI_startingZ;

    [SerializeField] public bool PSI_jumping;
    public State<Matt_SM_PlayerStateInfo> scheduledState = null;
    public bool switchState = false;
    public float gameTimer;
    public int seconds = 0;


    [Header("Float test")]
   [SerializeField] float startFloat;
    [SerializeField] float objectiveFloat;
    [SerializeField] float currentFloat;
    #region locking and unlocking
    public void LockAttack()
    {
        PSI_attackLock = true;
    }
    public void UnLockAttack()
    {
        PSI_attackLock = false;
    }
    public void LockGravity()
    {
        PSI_gravityLock = true;

    }
    public void UnLockGravity()
    {

        PSI_gravityLock = false;
    }
    public void LockMovement()
    {
        PSI_movementLock = true;
    }
    public void UnLockMovement()
    {
        PSI_movementLock = false;

    }

    public bool CheckMovementLock()
    {
        return PSI_movementLock;
    }
    public bool CheckGravityLock()
    {

        return PSI_gravityLock;
    }
    public bool CheckAttackLock()
    {

        return PSI_attackLock;
    }
    #endregion
    private Matt_SM_StateMachine<Matt_SM_PlayerStateInfo> stateMachine { get; set; }

    private void Start()
    {
        PSI_characterController = GetComponent<CharacterController>();

        PSI_inputSource = GetComponent<AbstractInput>();
        pSI_startingZ = gameObject.transform.position.z;

        anim = gameObject.GetComponent<Animator>();
        stateMachine = new Matt_SM_StateMachine<Matt_SM_PlayerStateInfo>(this);
        //stateMachine.ChangeState(FirstState.Instance);
        gameTimer = Time.time;
        stateMachine.ChangeState(new Matt_SM_FreeMoveState());
    }
    private void FixedUpdate()
    {
        currentPos = gameObject.transform.position - lastPos;
        lastPos = currentPos;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, pSI_startingZ);
    }
    private void Update()
    {
      //  currentFloat = Mathf.Lerp(startFloat, objectiveFloat, 0.1f);
        if (currentFloat >= objectiveFloat)
        {
            Debug.Log("objective reached for float test");
        }
        PSI_Grounded = GetComponent<CustomGrounder>().IsCustomGrounded();
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
