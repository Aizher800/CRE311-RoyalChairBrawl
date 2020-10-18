
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TSC_INPUT_SYSTEM;

using UnityEngine.InputSystem;
using _InputTest.Entity.Scripts.Input;
using _InputTest.Entity.Scripts.Input.Monobehaviours;


//namespace _InputTest.Entity.Scripts.Input.Monobehaviours
//{
[RequireComponent(typeof(CharacterController))]
[CreateAssetMenu(fileName = "PlayerMovementController", menuName = "Commands/Movement/Player Movement Command")]
public class PlayerMovementController : Matt_StateSystem.Command<Matt_SM_PlayerStateInfo>
{
  
       // [SerializeField] public AscendDescendCheck descendChecker;

        [SerializeField] public AnimatorOverrideController animOverride;
        public bool slowedWalk = false;
    private static PlayerMovementController _instance;

    [SerializeField] float jumpStrength = 2.8f;
    [SerializeField] float speed = 20f; //how fast the character moves, the smoothing of the movement is handled by the "Gravity" and "Sensitivity" settings in the Unity Input manager

    [SerializeField] bool Jogging;
 
   
        private float JogSpeed;
        private float walkSpeed;
        private float slowWalkSpeed;
        private Vector3 desiredMoveDirection; //Vector that holds desired Move Direction
        private bool blockRotationPlayer = false; //Block the rotation of the player?
        [Range(0, 0.5f)] public float desiredRotationSpeed = 0.1f; //Speed of the players rotation
        public Animator anim; //Animator
                              //private float JogSpeed; //Speed player is moving
        [Range(0, 1f)] public float allowPlayerRotation = 0.1f; //Allow player rotation from inputs once past x
        public Camera cam; //Main camera (make sure tag is MainCamera)
        public CharacterController controller; //Character Controller, auto added on script addition
   // private GameObject commandMasterOwner;
        private bool isGrounded; //is Grounded - work in progress

        [SerializeField] float moveSpeed = 20f; //how fast the character moves, the smoothing of the movement is handled by the "Gravity" and "Sensitivity" settings in the Unity Input manager

    float startingZPos = 0f;

   [SerializeField] bool _jumping = false;
    Vector3 movement; //the movement vector3
        private float verticalVel; //Vertical velocity -- currently work in progress
        private Vector3 moveVector; //movement vector -- currently work in progress


    private Vector3 moveDirection;
    Vector3 velocity;
    AbstractInput inputSource;
   // private IMoveInput _move;
    private IRotationInput _rotate;
    private IMoveinput _movement;
    private Coroutine _moveCoroutine;
    private Coroutine _rotateCoroutine;
    private Coroutine _jumpCoroutine;
    TSC_INPUT _inputActions;

    //private GameObject commandOwner;

         #region Initialization
    // Initialization of variables
    //private PlayerInputActions _inputActions;
   // private static PlayerMovementController _instance;


    public static PlayerMovementController Instance
    {
        get
        {
            if (_instance == null) 
            {
               _instance = new PlayerMovementController();

            }         
            return _instance;
        }
    }
    override public void EnableCommand(Matt_SM_PlayerStateInfo _owner)
    {
        commandUpdate = false;
        // commandName  = ("PlayerMovementController");
        _rotate = _owner.GetComponent<IRotationInput>();
        _movement = _owner.GetComponent<IMoveinput>();
        _owner.PSI_inputSource.OnMoveEvent += RunCommand;
        _owner.PSI_inputSource.OnJumpInputEvent += StartJump;
        Debug.Log("set plkayermovemtn owner to " + _owner);
        // stateInfo = enableOwner.GetComponent<PlayerStateInfo>();


       // _owner.PSI_inputSource.OnJogHoldEvent += JogToggle;
       // _owner.PSI_inputSource.OnJogReleaseEvent += JogFinish;
       //  _inputActions = new PlayerinputActions();
        //m_PlayerInput = enableOwner.GetComponent<PlayerInput>();
        anim = _owner.PSI_animator;
       // anim.applyRootMotion = false;
        anim.SetFloat("InputMagnitude", 0, 0.0f, Time.deltaTime);
        anim.SetFloat("InputX", 0f);


      //  moveDirection = Vector3.zero;        // _move = _owner.GetComponent<IMoveInput>();
        _rotate = _owner.GetComponent<IRotationInput>();
       // stateInfo = commandOwner.GetComponent<PlayerStateInfo>();
      //  commandId = stateInfo.PSI_uniqueId;

        //descendChecker = enableOwner.GetComponent<AscendDescendCheck>();
      //  anim = enableOwner.GetComponent<Animator>();
       // cam = Camera.main;
       // controller = commandOwner.GetComponent<CharacterController>();
       // commandId = stateInfo.PSI_uniqueId;
        if (anim == null)
        {
            Debug.LogError("We require " + _owner.transform.name + " game object to have an animator. This will allow for Foot IK to function");
        }


    }



    public void JogToggle(Matt_SM_PlayerStateInfo _owner)
    {
        if (_owner)
        Jogging = true;

    }

    public void JogFinish()
    {
        Jogging = false;


    }




    #region JUMPING
    void StartJump(Matt_SM_PlayerStateInfo _owner)
    {
        if (_jumping != true)
        {
            if (_owner.PSI_Grounded == true) //Check if grounded first so the player can't just quadruple jump into space, but we could perhaps have double-jumping  characters later down the line!
            {

                if (_jumpCoroutine == null)
                {
                    Debug.Log("Jumped!");
              
                    _jumpCoroutine = _owner.StartCoroutine(Jump(_owner));
                    _owner.PSI_animator.SetBool("PlayerJumping", true);

                }
                else
                {
                    Debug.Log("Still got a jump coroutine");
                }
            }
        }
        else
        {

            Debug.Log("still jumping");
        }
    }
    IEnumerator Jump(Matt_SM_PlayerStateInfo _owner)
    {
        _owner.SetJumpingStatus(true);
       
      while (_owner.PSI_jumpVelocity < jumpStrength * 0.9f) 
      {
            _owner.PSI_jumpVelocity = Mathf.Lerp(_owner.PSI_jumpVelocity, jumpStrength, .1f);
            yield return null;
            _owner.PSI_characterController.Move(new Vector3(0, jumpStrength - _owner.PSI_jumpVelocity, 0));
      }

      yield return new WaitUntil(() => (_owner.PSI_Grounded == false));
      {
             _jumping = true;
      }
        

      yield return new WaitUntil(() => (_owner.PSI_Grounded == true));
           {
                //Debug.Log("landed");
           _owner.PSI_jumpVelocity = 0f;
            _owner.PSI_animator.SetBool("PlayerJumping", false);
            _jumping = false;
           _jumpCoroutine = null;
            yield return null;
           }
        _owner.SetJumpingStatus(false);
        _owner.PSI_animator.SetBool("PlayerJumping", false);
        _jumpCoroutine = null;
        yield return null;
        Debug.Log("finished JUmp");

    }



    void CheckDirection(Matt_SM_PlayerStateInfo _owner, float value)
    {
        if (value > 0f)
        {
           _owner.PSI_direction  = Direction.RIGHT;
        }
        else
        {
            _owner.PSI_direction = Direction.LEFT;
        }
    }
    #endregion
    public override void RunCommand(Matt_SM_PlayerStateInfo _owner, Vector2 value)
    {
       
        if (_owner.CheckMovementLock() == true) { Debug.Log("movement was locked"); return; }
        var moveValue = value;
        var cam = Camera.main;
        var forward = cam.transform.forward;
        var right = cam.transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        moveDirection = forward * moveValue.y + right * moveValue.x;
        if (moveValue.x != 0f) { 
        _owner.UpdateDirection(moveValue.x);
        }
        moveDirection = moveDirection.normalized;
       //  Debug.Log("Executed Movement");
     

        if (_moveCoroutine == null)
        {
            

            
            _moveCoroutine = _owner.StartCoroutine(InputMagnitude(_owner));
            // Debug.Log("Moving!");
        }
        // InputMagnitude();



        if (_rotateCoroutine == null)
        {
            _rotateCoroutine = _owner.StartCoroutine(PlayerRotation(_owner));

        }

    }
    #region input implementation


    #endregion
    public AnimatorOverrideController GetOverrideController()
        {
            return animOverride;
        }


        IEnumerator PlayerRotation(Matt_SM_PlayerStateInfo _owner)
    {
     
        while (moveDirection != Vector3.zero)
        {

       
            yield return new WaitUntil(() => (_rotate.RotationDirection == Vector3.zero));

            if (moveDirection == Vector3.zero) continue;


            if (blockRotationPlayer == false)
            {

                _owner.visualRotationObject.rotation = Quaternion.Slerp(_owner.visualRotationObject.rotation, Quaternion.LookRotation(new Vector3(moveDirection.x, 0, moveDirection.z)), desiredRotationSpeed);

            }
        }
        Jogging = false;
        _rotateCoroutine = null;

         }

        #region FreeMoveMovement

        IEnumerator InputMagnitude(Matt_SM_PlayerStateInfo _owner)
        {

        _owner.SetMovingStatus(true);
       
        Animator ownAnimator = null;
      
        if (ownAnimator == null)
        {

            ownAnimator = _owner.PSI_animator;
        }
        while (moveDirection.x != 0 && moveDirection.z != 0)
        {
           
            //  Debug.Log("freemove movement");
            // calculate the input magnitutde
            walkSpeed = new Vector2(moveDirection.x, moveDirection.z).sqrMagnitude / 2;
            walkSpeed = Mathf.Clamp(walkSpeed, 0f, .5f);
            JogSpeed = new Vector2(moveDirection.x, moveDirection.z).sqrMagnitude;
            JogSpeed = Mathf.Clamp(JogSpeed, 0f, 1f);

            //Physically move the player;
          //  anim.SetFloat("InputX", 0f, .7f, Time.deltaTime);
            if (JogSpeed > allowPlayerRotation)
            {
              
                if (Jogging == true)
                {
                    // Speed = Mathf.Lerp(Speed, 1f, 2f);
                    ownAnimator.SetFloat("InputMagnitude", JogSpeed, .2f, Time.deltaTime);
                    _owner.PSI_characterController.Move(moveDirection * (speed * _owner.PSI_CharacterInfo.speedMultiplier) * Time.deltaTime); //The left-right movement of the player is handled here.
                                                                                   // descendChecker.AscendDescendChecker();
                }  
                else
                {

                    _owner.PSI_characterController.Move(moveDirection * (speed * _owner.PSI_CharacterInfo.speedMultiplier) * Time.deltaTime); //The left-right movement of the player is handled here.
                    ownAnimator.SetFloat("InputMagnitude", walkSpeed, 0.2f, Time.deltaTime);
                   
                }


                //PlayerMove(context);
               // PlayerRotation();
            }
            else if (JogSpeed > allowPlayerRotation)
            {
                ownAnimator.SetFloat("InputMagnitude", walkSpeed, 0.0f, Time.deltaTime);

            }

            if (moveDirection.x == 0 && moveDirection.z == 0)
            {

                ownAnimator.SetFloat("InputMagnitude", 0f, 0.1f, Time.deltaTime);
                _moveCoroutine = null;
            }
            yield return null;

        }
        moveDirection = Vector3.zero;
        ownAnimator.SetFloat("InputMagnitude", 0f);
        _owner.SetMovingStatus(false);

        // Debug.Log("NO MOVEmENT");
        _moveCoroutine = null;
        yield return null;
        //bool isRunning = false;
        //since this is called without any if statement requirements on update, CharacterPhysics is basically a glorified Update function at this point :p
    }
    #endregion

    //PHYSICS



    public override void DisableCommand(Matt_SM_PlayerStateInfo _owner)
    {
        _owner.PSI_inputSource.OnMoveEvent -= RunCommand;

        //_owner.PSI_inputSource.OnJogHoldEvent -= JogToggle;
        //_owner.PSI_inputSource.OnJogReleaseEvent -= JogFinish;
        base.DisableCommand(_owner);

        
      //  _owner.PSI_Velocity = Vector3.zero;
      
        _owner.PSI_animator.SetFloat("InputMagnitude", 0, 0.0f, Time.deltaTime);
        _owner.PSI_animator.SetFloat("InputX", 0f);
        if (_moveCoroutine != null)
        {
          _moveCoroutine = null;
            // Debug.Log("Moving!");
        }

        if (_rotateCoroutine != null)
        {
           _rotateCoroutine = null;
        }
        if(_moveCoroutine == null)
        {
            Debug.Log("move disabled");
        }

    }

    #endregion
}