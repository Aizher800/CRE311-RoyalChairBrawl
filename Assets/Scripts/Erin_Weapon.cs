using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Erin_Weapon : MonoBehaviour
{
    public float range;
    public float damage;
    private float speed = 2f;
    
    private void Start()
    {
        transform.position = Vector3.zero;
        


    }


    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }


    private void OnTriggerExit(Collider other)
    {
        
    }


    void Update()
    {
        
    }
}
