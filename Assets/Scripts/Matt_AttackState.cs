using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matt_AttackState : StateMachineBehaviour
{
    // Start is called before the first frame update
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Attacking");
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}

