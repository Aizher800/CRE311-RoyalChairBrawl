using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterYVelocity : MonoBehaviour
{

    Animator anim;

    float currentY_Position;
    float lastY_Position;

   public float yVelocity;
    // Update is called once per frame

    private void Start()
    {
        anim = GetComponent<Animator>();
        
    }

  

    void Update()
    {
        currentY_Position = transform.position.y;
        yVelocity = currentY_Position * 2f - lastY_Position * 2f;
        lastY_Position = currentY_Position;
        anim.SetFloat("velocityY", yVelocity);
    }
}
