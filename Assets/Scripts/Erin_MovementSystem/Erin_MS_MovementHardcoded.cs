//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.InputSystem;

//public class Erin_MS_MovementHardcoded : MonoBehaviour
//{
//    [SerializeField]
//    private float movementSpeed = 5f;


//    void Start()
//    {
//        Move();
//    }


//    private void Move()
//    {
//        var movement = new Vector3();


//       // There is a better way of doing this instead of hardcoding.
//       //if(Keyboard.current.  whatever key  .boolean)
//        if(Keyboard.current.wKey.isPressed)
//        {
//            movement.z += 1;      // z axis is forward and back movement.
//        }

//        if (Keyboard.current.sKey.isPressed)
//        {
//            movement.z -= 1;      // z axis is forward and back movement.
//        }

//        if (Keyboard.current.aKey.isPressed)
//        {
//            movement.x -= 1;      // x axis is left and right movement - all we need.
//        }

//        if (Keyboard.current.dKey.isPressed)
//        {
//            movement.x += 1;      // x axis is left and right movement -  all we need.
//        }

//        movement.Normalize();   //If we're moving diagonally, it won't go faster.

//        transform.Translate(movement * movementSpeed * Time.deltaTime);
//    }
//}
