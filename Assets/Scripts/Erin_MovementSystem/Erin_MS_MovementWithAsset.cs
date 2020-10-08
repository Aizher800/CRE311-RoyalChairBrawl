//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Erin_MS_MovementWithAsset : MonoBehaviour
//{
//    [SerializeField]
//    private float movementSpeed = 5f;

//    [SerializeField]
//    private float jumpHeight = 2;

//    private Erin_MS_Controls controls = null;


//    private void Awake()
//    {
//        controls = new Erin_MS_Controls(); 
//    }


//    private void OnEnable()
//    {
//        controls.Player.Enable();       // Player controls enabled whenever player is.
//    }


//    private void OnDisable()
//    {
//        controls.Player.Disable();
//    }


//    private void Update()
//    {
//        Move();
//    }


//    public void Jump()
//    {
//        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
//    }


//    private void Move()
//    {
//        var movementInput = controls.Player.Movement.ReadValue<Vector2>();  // Whatever the movement is, read it as a vector 2. Hardcoded - no string references.

//        var movement = new Vector3();   // Reads input value.
//        movement.x = movementInput.x;   // Convert it into the format we want.
//        movement.z = movementInput.y;   // Convert it into the format we want.

//        movement.Normalize();   //If we're moving diagonally, it won't go faster.

//        transform.Translate(movement * movementSpeed * Time.deltaTime);
//    }

//}
