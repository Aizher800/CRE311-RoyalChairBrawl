using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Erin_Weapon : MonoBehaviour
{
<<<<<<< HEAD
    public float range;
    public float damage;
    private float speed = 2f;
    
    private void Start()
    {
        transform.position = Vector3.zero;
        


=======

    public float range;
    public float damage;

    

    void Start()
    {
        
>>>>>>> Matt_Branch
    }


    void FixedUpdate()
    {
<<<<<<< HEAD
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }


    private void OnTriggerExit(Collider other)
    {
=======
>>>>>>> Matt_Branch
        
    }


    void Update()
    {
        
    }
}
