using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using _InputTest.Entity.Scripts.Input.Monobehaviours.Commands;
using _InputTest.Entity.Scripts.Input;

using System.Collections.Concurrent;
namespace _InputTest.Entity.Scripts.Input.Monobehaviours

{
    public class AbstractInput : MonoBehaviour
    {

        Matt_SM_PlayerStateInfo thisOwner;
        [Header("Input Values")]
        [Space(20)]
        [SerializeField]
        private Vector3 rotationDirection;

        //[SerializeField] public Vector3 moveDirection;
        [SerializeField] private bool isPressingInteract;
        [SerializeField] private bool isUsingSkill;
        [SerializeField] private bool isAttacking;
        //[SerializeField] private bool isJogging;


            //EVENTS
        public delegate void MoveInputEvent(Matt_SM_PlayerStateInfo _owner, Vector2 inputValue);
        public event MoveInputEvent OnMoveEvent;

        public delegate void AnalogAimEvent(Matt_SM_PlayerStateInfo _owner, Vector2 aimvalue);
        public  event AnalogAimEvent OnAimEvent;


        public delegate void JogHoldEvent();
        public event JogHoldEvent OnJogHoldEvent;

        public delegate void JogReleaseEvent();
        public event JogReleaseEvent OnJogReleaseEvent;

        public delegate void UpdateEvent(GameObject owner);
        public  event UpdateEvent OnUpdateEvent;


        public delegate void SkillUseEvent();
        public event SkillUseEvent OnSkillEvent;

        //Imove variable
        //public Vector3 MoveDirection => moveDirection;
        public Vector3 RotationDirection
        {
            get => rotationDirection;
            set => rotationDirection = value;
        }
        public bool IsUsingSkill => isUsingSkill;
        public bool IsPressingInteract => isPressingInteract;
        public bool IsAttacking => isAttacking;

       // private PlayerInput m_PlayerInput;

        private string _uniqueID;

        //Imove variable
        // public bool IsJogging => isJogging;



        // Start is called before the first frame update
        void Start()
        {
            thisOwner = GetComponent<Matt_SM_PlayerStateInfo>();
           // _uniqueID = gameObject.GetComponent<UniqueId>().uniqueId;
            Debug.Log("Set Unique id to " + _uniqueID);
        }

        // Update is called once per frame
        void Update()
        {
             
        }

        protected void OnAimInput(Vector2 value)
        {
            OnAimEvent?.Invoke(thisOwner, value);
        }
        protected void OnMoveInput(Vector2 inputValue)
        {

            OnMoveEvent?.Invoke(thisOwner, inputValue);
        }
        public void OnSkillUse()
        {
            OnSkillEvent?.Invoke();
           // isUsingSkill = true;
            //if (skillInput != null)
              //  skillInput.Execute();
        }

        public void OnJogHold()
        {
           OnJogHoldEvent?.Invoke();

        }

        public void OnJogRelease()
        {

            OnJogReleaseEvent?.Invoke();
        }
        /* public void OnAnalogAimInput(InputAction.CallbackContext context)
         {
             var value = context.ReadValue<Vector2>();
             rotationDirection = new Vector3(value.x, 0, value.y);
             if (analogRotationInput != null)
                 analogRotationInput.Execute();
         }

         public void OnInteractStart(InputAction.CallbackContext context)
         {
             Debug.Log("INTERACTING");
             if (context.control.displayName != LeftMouseButton) return;
             isPressingInteract = true;
             mouseRotationInput.Execute();
         }

         public void OnInteractEnded(InputAction.CallbackContext context)
         {
             if (interactInput != null)
                 interactInput.Execute();

             isPressingInteract = false;

             if (context.action.activeControl.device != Mouse.current) return;
             rotationDirection = Vector3.zero;
         }

     

         private void OnSkillEnd(InputAction.CallbackContext context)
         {
             isUsingSkill = false;
             if (skillInput != null)
                 skillInput.Complete();
         }

         private void OnAttackStart(InputAction.CallbackContext context)
         {
             isAttacking = true;
             if (attackInput)
                 attackInput?.Execute();
         }

         private void OnAttackEnd(InputAction.CallbackContext context)
         {
             isAttacking = false;
             if (attackInput)
                 attackInput.Complete();
         }

         */

    }
}