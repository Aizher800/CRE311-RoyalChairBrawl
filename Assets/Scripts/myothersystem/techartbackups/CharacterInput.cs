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
        [SerializeField] public PlayerInputNum playerInput;
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
                    _inputSource.Player1.Fire.performed += FireConversion;
                    _inputSource.Player1.Block.performed += BlockHold;
                    //_inputSource.Player1.Block.performed += BlockRelease;
                    break;

                case (PlayerInputNum.Player2):
                    _inputSource.Player2.Move.performed += MovementConversion;
                    _inputSource.Player2.Jump.performed += JumpConversion;
                    _inputSource.Player2.Interact.started += InteractConversion;
                    _inputSource.Player2.Fire.performed += FireConversion;
                    _inputSource.Player2.Block.performed += BlockHold;
                  //  _inputSource.Player2.Block.performed += BlockRelease;
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

           
        }
        void FireConversion(InputAction.CallbackContext context)
        {
            OnFireUse();
           
        }

        void AimConversion(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<Vector3>();
            OnAimInput(value);

        }
        void MovementConversion(InputAction.CallbackContext context)
        {


            var value = context.ReadValue<Vector2>();

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
        void BlockHold(InputAction.CallbackContext context)
        {
            var value = context.ReadValueAsButton();
            OnBlockHold(value);
            Debug.Log("blockhold input");
        }
        void BlockRelease(InputAction.CallbackContext context)
        {
            OnBlockRelease();
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