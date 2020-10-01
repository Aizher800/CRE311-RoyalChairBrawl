
using UnityEngine.InputSystem;
using UnityEngine;

using TSC_INPUT_SYSTEM;


namespace _InputTest.Entity.Scripts.Input.Monobehaviours
{
    public class CharacterInput : AbstractInput//,// IInteractInput, IRotationInput, ISkillInput, IAttackInput
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

        [SerializeField] TSC_INPUT _inputSource;
        [SerializeField] float inputX;
        [SerializeField] float inputY;
        private void Awake()
        {
            
            if (_inputSource == null)
            {
                _inputSource = new TSC_INPUT();
            }
        }

        
        private void OnEnable()
        {
           _inputSource.Enable();

             _inputSource.Player.Move.performed += MovementConversion;

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
          
            OnMoveInput(value);
           
           

        }

        void SkillConversion(InputAction.CallbackContext context) 
        {
            var value = context;

            OnSkillUse();
        }

        void EndMovement(InputAction.CallbackContext context)
        {


        }

        void JogHold(InputAction.CallbackContext context)
        {
            OnJogHold();

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