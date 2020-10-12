using TSC_INPUT_SYSTEM;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _InputTest.Entity.Scripts.Input.Monobehaviours
{
    public enum PlayerInputNum
    {

        Player1,
        Player2,
        Player3,
        Player4
    }
    public class CharacterInput : AbstractInput, IRotationInput, IMoveinput
    {
        /*  [Header("Input Commands")] 
          public Command interactInput;
          public Command movementInput;
          public Command analogRotationInput;
          public Command mouseRotationInput;
          public Command skillInput;
          public Command attackInput;

          */

        // [SerializeField]  PlayerInputActions _inputActions;

        private const string LeftMouseButton = "Left Button";
        [SerializeField] PlayerInputNum playerInput;
        [SerializeField] TSC_INPUT _inputSource;
        [SerializeField] float inputX;
        [SerializeField] float inputY;
        private Vector3 moveDirection;
        public Vector3 MoveDirection => moveDirection;
       
        
        private void Awake()
        {
            
            if (_inputSource == null)
            {
                _inputSource = new TSC_INPUT();
               
            }
        }
       void SetInput()
        {
            _inputSource.Enable();
            switch (playerInput)
            {
                case (PlayerInputNum.Player1):
                    _inputSource.Player1.Move.performed += MovementConversion;
                    _inputSource.Player1.Jump.performed += JumpConversion;
                    _inputSource.Player1.Interact.started += InteractConversion;
                    break;

                case (PlayerInputNum.Player2):
                    _inputSource.Player2.Move.performed += MovementConversion;
                    _inputSource.Player2.Jump.performed += JumpConversion;
                    _inputSource.Player2.Interact.started += InteractConversion;
                    break;

                case (PlayerInputNum.Player3):

                    break;

                case (PlayerInputNum.Player4):



                    break;
            }
        }

        private void OnEnable()
        {
            SetInput();

            

            // _inputActions.Player1.AnalogAim.started += AimConversion;

            //  _inputActions.Player1.Jogging.started += JogHold;
            //  _inputActions.Player1.Jogging.canceled += JogRelease;
            //  _inputActions.Player1.Skill.performed += SkillConversion;
            /* if (analogRotationInput)
                 _inputActions.Player.AnalogAim.performed += OnAnalogAimInput;

             if (interactInput)
             {
                 _inputActions.Player.Interact.started += OnInteractStart;
                 _inputActions.Player.Interact.canceled += OnInteractEnded;
             }

             if (skillInput)
             {
                 _inputActions.Player.Skill.performed += OnSkillUse;
                 _inputActions.Player.Skill.canceled += OnSkillEnd;
             }

             if (attackInput)
             {
                 _inputActions.Player.Attack.performed += OnAttackStart;
                 _inputActions.Player.Attack.canceled += OnAttackEnd;
             }
             */
        }

        void AimConversion(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<Vector3>();
            OnAimInput(value);

        }
        void MovementConversion(InputAction.CallbackContext context)
        {


            var value = context.ReadValue<Vector2>();
            Debug.Log("move input received");
            inputX = value.x;
            inputY = value.y;
            OnMoveInput(value);



        }

        void SkillConversion(InputAction.CallbackContext context)
        {
            var value = context;

            OnSkillUse();
        }
        void InteractConversion(InputAction.CallbackContext context)
        {

            OnInteractPress();
        }
        void EndMovement(InputAction.CallbackContext context)
        {


        }

        void JogHold(InputAction.CallbackContext context)
        {
            OnJogHold();

        }
        void JumpConversion(InputAction.CallbackContext context)
        {
            OnJumpInput();
        }


        void JogRelease(InputAction.CallbackContext context)
        {

            OnJogRelease();
        }

        private void OnDisable()
        {
            //FIFX _inputActions.Player1.Movement.performed -= MovementConversion;
            // _inputActions.Player.Interact.started -= OnInteractStart;
            //  _inputActions.Player.Interact.canceled -= OnInteractEnded;
            // _inputActions.Player.AnalogAim.performed -= OnAnalogAimInput;
            // _inputActions.Player.Skill.performed -= OnSkillUse;

            //FIX THIS_inputActions.Disable();
        }

    }
}