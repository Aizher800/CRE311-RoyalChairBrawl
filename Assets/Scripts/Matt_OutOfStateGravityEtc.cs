using UnityEngine;

public class Matt_OutOfStateGravityEtc : MonoBehaviour
{
    CharacterController controller;
    public Vector3 velocityCore;
    [SerializeField] public bool isGrounded;
    float gravity = -29f;
    float velocityDamp = 3f; //velocityDamp is the rate at which the forces applied to the player revert to their original values
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    private void Update()
    {
        isGrounded = controller.isGrounded;
    }
    void FixedUpdate()
    {


        CharacterPhysics(); //since this is called without any if statement requirements on update, CharacterPhysics is basically a glorified Update function at this point :p
    }



    void CharacterPhysics()//this handles all the gravitational stuff affecting player, also jumping just adds a big burst of upwards momentum to the player
    {
        if (!controller.isGrounded)
        {
            velocityCore = Vector3.Lerp(velocityCore, new Vector3(0, gravity, 0), velocityDamp * Time.deltaTime);
            controller.Move(velocityCore * Time.deltaTime);
        }
        if (controller.isGrounded)
        {

            velocityCore = Vector3.zero;
            isGrounded = true;
        }
    }
}
