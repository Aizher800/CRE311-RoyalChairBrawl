using UnityEngine;




namespace ScriptableStateSystem
{

    public enum STATE
    {
        Null,
        FreeMove,
        Dead,
        Jumping,
        Attacking

    }
    public abstract class ScriptableState : ScriptableObject
    {

        public GameObject state_Owner { get; set; } //idk what the point of get set is again lol

        //The Initial Runner

        protected void B_OnStateEnter(GameObject _owner = null)
        {
            if (_owner != null) { state_Owner = _owner; }

            C_StateEntry();
        }

        protected void B_OnStateExit(GameObject _owner = null)
        {

            C_StateExit();
        }

        protected void B_OnStateUpdate()
        {

            C_StateUpdate();

        }

        //The Overriden Behaviour.

        public abstract void C_StateEntry();


        public abstract void C_StateExit();


        public abstract void C_StateUpdate();

    }

    public class ScriptableStateTest : ScriptableState
    {
        public override void C_StateEntry()
        {
            Debug.Log("State has been entered!");
        }

        public override void C_StateExit()
        {
            Debug.Log("State has been exited!");
        }

        public override void C_StateUpdate()
        {
            Debug.Log("State Updating!");
        }
    }


}