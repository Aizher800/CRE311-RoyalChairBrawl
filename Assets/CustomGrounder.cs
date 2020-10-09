using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGrounder : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float groundCastStart;
    [SerializeField] float groundCastLength;
    [SerializeField] bool newGrounded;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(gameObject.transform.position + new Vector3(0, groundCastStart, 0), -Vector3.up, out hit, groundCastLength ))
        {
            Debug.DrawRay(gameObject.transform.position + new Vector3(0, groundCastStart, 0), -Vector3.up, Color.red);
            Debug.Log(" the ground is called" + hit.transform.gameObject);
            newGrounded = true;
        }
        else
        {
            newGrounded = false;
        }
    }
}
