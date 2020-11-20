﻿using _InputTest.Entity.Scripts.Input.Monobehaviours;
using Matt_StateSystem;
using UnityEngine;
using System.Collections;
public enum Direction
{

    LEFT,
    RIGHT
}
public class Matt_SM_PlayerStateInfo : MonoBehaviour
{
    float victoryPercent;

    [SerializeField] public int state;
    public Vector3 navObjective;
    // public int specialAnimNumber;

    public Erin_UI_PlayerHealth playerHealth;
    public Matt_CharacterInfo PSI_CharacterInfo;
    public Matt_CharacterInfo PSI_DefaultCharInfo;
    GameObject psi_InstantiatedObject;
    public Direction PSI_direction;
    public AbstractInput PSI_inputSource;
    public Vector3 PSI_Velocity;

    public Animator PSI_animator;

   public CharacterController PSI_characterController;
    [SerializeField] public bool PSI_Grounded;
    public bool weaponReady = false;
    public bool lockedOn = false;
    Animator anim;

    [SerializeField] bool PSI_movementLock;
    [SerializeField] bool PSI_gravityLock;
    [SerializeField] bool PSI_attackLock;

    [SerializeField] public Transform visualRotationObject;
    

   [SerializeField] Vector3 lastPos;
   Vector3 currentPos;
   public float pSI_startingZ;

    [SerializeField] public bool PSI_jumping;
    public State<Matt_SM_PlayerStateInfo> scheduledState = null;
    public bool switchState = false;
    public float gameTimer;
    public int seconds = 0;

   
    public bool PSI_isAttacking { get; private set; }
    public bool PSI_isMoving { get; private set; }
    public bool PSI_isJumping { get; private set; }
    public bool PSI_isBlocking;

    public PlayerInputNum PSI_inputNum;
    [Header("Jumping")]
    [SerializeField] public float PSI_jumpVelocity;
    [SerializeField] float jumpGravity;
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

    #region actionNotifiers

    public void SetAttackStatus(bool _status)
    {
        PSI_isAttacking = _status;
        //Debug.Log("attacking is " + PSI_isAttacking);
    }

    public void SetMovingStatus(bool _status)
    {
        PSI_isMoving = _status;

    }
    public void SetJumpingStatus(bool _status)
    {

        PSI_isJumping = _status;
       // Debug.Log("jumping is " + PSI_isJumping);
    }

    #endregion
    private Matt_SM_StateMachine<Matt_SM_PlayerStateInfo> stateMachine { get; set; }
    private void Awake()
    {
        if (PSI_CharacterInfo != null)
        {
         //   LoadCharacterInfo(PSI_CharacterInfo);
        }
    }

    
    private void Start()
    {

        playerHealth = GetComponent<Erin_UI_PlayerHealth>();
     //   PSI_animator = GetComponent<Animator>();
        
        PSI_characterController = GetComponent<CharacterController>();

        PSI_inputSource = GetComponent<AbstractInput>();
        pSI_startingZ = gameObject.transform.position.z;
        PSI_inputNum = GetComponent<CharacterInput>().playerInput;
        anim = gameObject.GetComponent<Animator>();
        stateMachine = new Matt_SM_StateMachine<Matt_SM_PlayerStateInfo>(this);
        //stateMachine.ChangeState(FirstState.Instance);
        gameTimer = Time.time;
        stateMachine.ChangeState(new Matt_SM_FreeMoveState());
    }
   
    public void LoadCharacterInfo(Matt_CharacterInfo _charInfo)
    {
        if (_charInfo != null) {
            PSI_CharacterInfo = _charInfo;
            PSI_DefaultCharInfo = _charInfo;
            gameObject.name = _charInfo.characterName;
       psi_InstantiatedObject = Instantiate(_charInfo.characterVisual, this.transform);
        PSI_animator = psi_InstantiatedObject.GetComponent<Animator>();
        visualRotationObject = psi_InstantiatedObject.GetComponent<Matt_VisualRotation>().transform;
        }
    }

  
    
    private void FixedUpdate()
    {
        currentPos = gameObject.transform.position - lastPos;
        lastPos = currentPos;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, pSI_startingZ);

        if (PSI_Velocity != Vector3.zero)
        {
            Debug.Log("Velocity NOT 0");
            PSI_Velocity = Vector3.Lerp(PSI_Velocity, Vector3.zero, 4f * Time.deltaTime);
            PSI_characterController.Move(PSI_Velocity);
        }
        else
        {

            Debug.Log("VELOCITY WAS 0");
        }
    }

    
    public void UpdateDirection(float xValue)
    {
        if (xValue > 0f)
        {
            PSI_direction = Direction.RIGHT;
            gameObject.transform.rotation = Quaternion.LookRotation(new Vector3(-1f, 0, 0));

        }
        else
        {
            PSI_direction = Direction.LEFT;
            gameObject.transform.rotation = Quaternion.LookRotation(new Vector3(1f, 0, 0));
        }

    }
    private void Update()
    {
        //  currentFloat = Mathf.Lerp(startFloat, objectiveFloat, 0.1f);

        Debug.DrawRay(gameObject.transform.position, transform.forward, Color.red);
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
    public void Boost(PowerUp p_up)
    {

        StartCoroutine(BoostReset(p_up));
    }
    public IEnumerator BoostReset(PowerUp p_up)
    {

        float oldValue = 1f;
        int oldInt = 0;
        Debug.Log("POWERUP ACTIVATED");
        switch (p_up._powerUpValues.type)
        {
            case PowerUpType.HEALING:
                break;
            case PowerUpType.ENERGY:
                break;
            case PowerUpType.SPEED:
                oldValue = PSI_CharacterInfo.speedMultiplier;
                PSI_CharacterInfo.speedMultiplier = p_up._powerUpValues._speedBoost;
              
                
                break;
            case PowerUpType.DAMAGE:
                oldValue = PSI_CharacterInfo.attackMultiplier;
                PSI_CharacterInfo.attackMultiplier = p_up._powerUpValues._damageBoost;
                break;
            default:
                break;
        }
        yield return new WaitForSeconds(p_up._powerUpValues._boostDuration);
        switch (p_up._powerUpValues.type)
        {
            case PowerUpType.HEALING:
                break;
            case PowerUpType.ENERGY:
                break;
            case PowerUpType.SPEED:

                PSI_CharacterInfo.speedMultiplier = oldValue;
                break;
            case PowerUpType.DAMAGE:
                PSI_CharacterInfo.attackMultiplier = oldValue;
                break;
            default:
                break;
        }
        Debug.Log("POWERUP ENDED");
        yield return null;
    }

}
