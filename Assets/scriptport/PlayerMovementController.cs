
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
  
    Matt_SM_PlayerStateInfo stateInfo;
       // [SerializeField] public AscendDescendCheck descendChecker;

        [SerializeField] public AnimatorOverrideController animOverride;
        public bool slowedWalk = false;
    private static PlayerMovementController _instance;

    [SerializeField] float jumpStrength = 40f;
    [SerializeField] float speed = 20f; //how fast the character moves, the smoothing of the movement is handled by the "Gravity" and "Sensitivity" settings in the Unity Input manager

    [SerializeField] bool Jogging;
        [SerializeField] private bool knockedOnBack = false;

        private float InputX; //Left and Right Inputs
        private float InputZ; //Forward and Back Inputs
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
        anim = _owner.GetComponent<Animator>();
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


        var jumpVelocity = Vector3.zero;
        if (jumpVelocity.y != jumpStrength) {
        jumpVelocity = Vector3.Lerp(Vector3.zero, new Vector3(0,  jumpStrength, 0), 0.4f); //simply adds the force of "JumpStrength" to the velocity, making the player "jump" upwards
        }
        _owner.PSI_characterController.Move(jumpVelocity);
        yield return new WaitUntil(() => (_owner.PSI_Grounded == false));
        {
            Debug.Log(" int the air");
            _jumping = true;
        }
        

        yield return new WaitUntil(() => (_owner.PSI_Grounded == true));
            {
                Debug.Log("landed");
                _jumping = false;
                _jumpCoroutine = null;
                yield return null;
            }
        _jumpCoroutine = null;
        yield return null;
        Debug.Log("finished JUmp");

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
        moveDirection = moveDirection.normalized;
       //  Debug.Log("Executed Movement");


        if (_moveCoroutine == null)
        {
            
                Debug.Log("move was disabled e");
            
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
                Debug.Log("Rotate");
                _owner.transform.rotation = Quaternion.Slerp(_owner.transform.rotation, Quaternion.LookRotation(new Vector3(moveDirection.x, 0, moveDirection.z)), desiredRotationSpeed);

            }
        }
        Jogging = false;
        _rotateCoroutine = null;

         }

        #region FreeMoveMovement

        IEnumerator InputMagnitude(Matt_SM_PlayerStateInfo _owner)
        {
        
        
        CharacterController ownController = null;
        Animator ownAnimator = null;
      
        if (ownAnimator == null)
        {

            ownAnimator = _owner.GetComponent<Animator>();
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
                    _owner.PSI_characterController.Move(moveDirection * speed * Time.deltaTime); //The left-right movement of the player is handled here.
                                                                                   // descendChecker.AscendDescendChecker();
                }  
                else
                {
                    Debug.Log("moving character: " + _owner);
                    _owner.PSI_characterController.Move(moveDirection * speed * Time.deltaTime); //The left-right movement of the player is handled here.
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
      
        anim.SetFloat("InputMagnitude", 0, 0.0f, Time.deltaTime);
        anim.SetFloat("InputX", 0f);
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