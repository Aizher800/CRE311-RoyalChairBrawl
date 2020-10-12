using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickUpable
{
    void PickUpItem();

}
public interface IInteractable
{
     void Interact();
}
public class GroundItem : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
   public void Interact()
    {
        Debug.Log("ya got me!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
}
