﻿using UnityEngine;

namespace Matt_StateSystem
{
    public class Matt_SM_StateMachine<T>
    {
        public State<T> currentState { get; private set; }
        public State<T> previousState { get; private set; }
        public T Owner;

        public Matt_SM_StateMachine(T _o)
        {
            Owner = _o;
            currentState = null;
            previousState = null;
        }

        public void ChangeState(State<T> _newstate)
        {
           
            
            if (currentState != null)
            {
                //if (previousState != null) { 
                if (currentState.stateNumber != _newstate.stateNumber)
                {
                    Debug.Log("state number " + currentState.stateNumber.ToString() + " and state number " + _newstate.stateNumber.ToString() + "are darn tootin different!!!");

                    if (_newstate.restorableState)
                    {
                        previousState = _newstate;
                    }
                    currentState.ExitState(Owner);
                }

                else
                {
                    Debug.Log("These dang states are the same");
                    return;
                }

            }
            
            Debug.Log("New State number for" + _newstate.ToString() + " is: " + _newstate.stateNumber);
             currentState = _newstate;
             currentState.EnterState(Owner);
           
        }
        public void RestoreState()
        {
            //why the fuck does this never work?
            //if the state changes to itself repeatedly that should not be allowed.
            if (previousState != null)
            {
                Debug.Log("Attempting to restore state to" + previousState.ToString());
                ChangeState(previousState);
            }
            else
            {
                Debug.Log("no state to return to.");
            }
        }
        public void Update()
        {
            if (currentState != null)
                currentState.UpdateState(Owner);
        }

        public int GetStateNumber()
        {
            int stateNum = currentState.stateNumber;
            Debug.Log(stateNum +"is the statenum we got");
            return stateNum;
        }
    }

    public abstract class State<T>
    {
        public bool restorableState = false;

       public int stateNumber;
        public abstract void EnterState(T _owner);
        public abstract void ExitState(T _owner);
        public abstract void UpdateState(T _owner);
    }
}