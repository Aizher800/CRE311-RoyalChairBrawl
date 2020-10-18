using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matt_Blocking : MonoBehaviour
{

    Matt_SM_PlayerStateInfo _thisOwner;
    // Start is called before the first frame update
    void Start()
    {
        _thisOwner = GetComponent<Matt_SM_PlayerStateInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
