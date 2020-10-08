//using _InputTest.Entity.Scripts.Input.Monobehaviours.Commands;
using _InputTest.Entity.Scripts.Input.Monobehaviours;
using System.Collections;
using UnityEngine;

public class KnockBackCommand : StateMachineBehaviour
{

    private Vector3 impactDirection;
    AbstractInput inputSource;
    // private IMoveInput _move;
    //private IRotationInput _rotate;
    private Coroutine _impactCoroutine;


    float velocityDamp = 1f; //velocityDamp is the rate at which the forces applied to the player revert to their original values
    Vector3 velocity; //basically all the gravity-based stuff affecting the player, velocity is added on top of the player movement vector3
    float gravity = -5f;

    Animator anim;
    GameObject commandOwner;
    [SerializeField] Vector3 impact;
    //PlayerInputActions _inputActions;

    CharacterController controller;
    // Start is called before the first frame update
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        //inputSource = animator.GetComponent<AbstractInput>();
        // inputSource.OnMoveEvent += RunCommand;
        commandOwner = animator.gameObject;
        Debug.Log("set owner to " + commandOwner);
        //   _inputActions = new PlayerInputActions();
        //m_PlayerInput = enableOwner.GetComponent<PlayerInput>();
        anim = animator.GetComponent<Animator>();
        anim.applyRootMotion = false;
        anim.SetFloat("InputMagnitude", 0, 0.0f, Time.deltaTime);
        anim.SetFloat("InputX", 0f);

        impact = -commandOwner.transform.forward * 33f + new Vector3(0, 60f, 0);
        //impactDirection = Vector3.zero;        // _move = _owner.GetComponent<IMoveInput>();
        // _rotate = commandOwner.GetComponent<IRotationInput>();
        // stateInfo = commandOwner.GetComponent<PlayerStateInfo>();
        //  commandId = stateInfo.PSI_uniqueId;

        //descendChecker = enableOwner.GetComponent<AscendDescendCheck>();
        //  anim = enableOwner.GetComponent<Animator>();
        // cam = Camera.main;
        controller = commandOwner.GetComponent<CharacterController>();


    }

    // Update is called once per frame


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {



        if (_impactCoroutine == null)
        {
            _impactCoroutine = commandOwner.GetComponent<Matt_SM_PlayerStateInfo>().StartCoroutine(CharacterPhysics());

        }


    }
    IEnumerator CharacterPhysics()//this handles all the gravitational stuff affecting player, also jumping just adds a big burst of upwards momentum to the player
    {

        //  anim.SetBool("ImpactFlying", true);
        // impact = Vector3.Lerp(impact, new Vector3(0, gravity, 0), velocityDamp * Time.deltaTime);
        //   controller.Move(impact * Time.deltaTime);

        // if (impact == Vector3.zero)
        // {
        while (Vector3.Distance(impact, Vector3.zero) > .1f)
        {

            // anim.SetBool("ImpactFlying", false);
            // yield return null;
            // _impactCoroutine = null;
            // }


            if (impact.magnitude > 0.1F) { controller.Move(impact * Time.deltaTime); }// THIS IS THE PART THAT ACTUALLY MOVES THE CHARACTER
                                                                                      // consumes the impact energy each cycle:
            impact = Vector3.Lerp(impact, Vector3.zero, 5f * Time.deltaTime);
            anim.SetBool("ImpactHitwall", true);
            yield return null;
        }

        Debug.Log("Impact ended.");
        anim.SetBool("ImpactHitwall", true);
        anim.SetBool("ImpactFlying", false);
        impact = Vector3.zero;
        //the char
        _impactCoroutine = null;
        yield return null;

    }
    // call this function to add an impact force:
    public void ReceiveHit(GameObject owner, GameObject receiver, Vector3 direction, float force, int damage) //a seperate script to set the state and animation,?
    {
        Debug.Log("responded to hit event!");
        if (receiver == commandOwner.gameObject)
        {
            Debug.Log(receiver.ToString() + "Reacting to hit from: " + owner.ToString());
            AddImpact(direction, force);

        }
        else
        {
            return;
        }

    }
    public void AddImpact(Vector3 dir, float force)
    {
        //garbage trash code, should probably have everything as an ihneritance abstract class thingy instead.
        //    if (commandOwner.GetComponent<PlayerStateInfo>())
        // {
        //   playerStateInfo = gameObject.GetComponent<PlayerStateInfo>();
        //  Debug.Log("Player Knockdown state not yet implemented.");

        //  }
        //    else if (gameObject.GetComponent<AI>())
        //  {
        //   aiStateInfo = gameObject.GetComponent<AI>();
        //   aiStateInfo.ChangeStateMachineState(AI_KnockDownState.Instance);
        //
        //   }
        //    anim.SetBool("ImpactFlying", true);
        //   isFlying = true;
        //  dir.Normalize();
        //   if (dir.y < 0) dir.y = -dir.y; // reflect down force on the ground
        //  impact += dir.normalized * force / mass;
    }
}
