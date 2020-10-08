
/*  COMMENTED OUT
public class AttackState : State<PlayerStateInfo>
{
    private static AttackState _instance;
    AttackTest attackTest;
    Vector3 playerTransform;
    private AttackState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }


    public static AttackState Instance
    {
        get
        {
            if (_instance == null)
            {
                new AttackState();
                Instance.stateNumber = 3;
                Instance.restorableState = false;
            }

            return _instance;
        }
    }

    public override void EnterState(PlayerStateInfo _owner)
    {
        //playerTransform = GameObject.FindObjectOfType<PlayerMovementController>().gameObject.transform.position;
        //  Debug.Log("Entering THIRD State");
        attackTest = _owner.GetComponent<AttackTest>();
        if (!attackTest)
        {
            attackTest = _owner.GetComponentInChildren<AttackTest>();
        }
       // attackTest.Attack();
        _owner.state = 3;

    }

    public override void ExitState(PlayerStateInfo _owner)
    {
        
        //Debug.Log("Exiting THIRD State");
    }

    public override void UpdateState(PlayerStateInfo _owner)
    {
        //if (!_owner.switchState)
        // {
        //   _owner.stateMachine.ChangeState(FirstState.Instance);
        // }
    }
}
*/