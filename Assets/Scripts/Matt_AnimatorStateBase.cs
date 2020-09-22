using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matt_AnimatorStateBase : StateMachineBehaviour
{

    #region variables

    public CharacterController b_controller { get; private set; }
    public GameObject b_commandOwner { get; private set; }
    public Animator b_anim { get; private set; }

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        b_controller = animator.gameObject.GetComponent<CharacterController>();
        b_commandOwner = animator.gameObject;
        b_anim = animator;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
    #endregion
    protected virtual void StartCommand()
    {


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
