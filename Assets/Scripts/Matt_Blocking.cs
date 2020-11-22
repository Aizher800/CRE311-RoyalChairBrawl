using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _InputTest.Entity.Scripts.Input.Monobehaviours;

public class Matt_Blocking : MonoBehaviour
{
   
    Matt_SM_PlayerStateInfo _thisOwner;
    
    // Start is called before the first frame update
    void Start()
    {
       // _thisOwner = GetComponent<Matt_SM_PlayerStateInfo>();
       
          //  _thisOwner.PSI_inputSource.OnBlockHoldEvent += ActivateBlock;
           // _thisOwner.PSI_inputSource.OnBlockReleaseEvent += ReleaseBlock;
        
      
            Debug.Log("fafafooeofeoyeoegfoegsodag");
        
    }
   public  void ActivateBlock(Matt_SM_PlayerStateInfo _owner)
    {
        Debug.Log("block activated");

    }

   public void ReleaseBlock(Matt_SM_PlayerStateInfo _owner)
    {
        Debug.Log("block released");

    }
}
