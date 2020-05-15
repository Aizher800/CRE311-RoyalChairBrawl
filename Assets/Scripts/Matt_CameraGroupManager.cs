using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

//MAKE SURE THE MAINCAMERA HAS A CINEMACHINE BRAIN BTW
public class Matt_CameraGroupManager : MonoBehaviour
{

    [SerializeField] CinemachineTargetGroup cinemachineTargetGroup;
    // Start is called before the first frame update
    void Start()
    {

        cinemachineTargetGroup = FindObjectOfType<CinemachineTargetGroup>();


        //gets every player in the scene and adds them to the target group on awake ghfsggkjsfhwrguifdsikoa
        for (int i = 0; i < FindObjectsOfType<Erin_UI_PlayerHealth>().Length; i++)
        {
            cinemachineTargetGroup.AddMember(GameObject.FindObjectsOfType<Erin_UI_PlayerHealth>()[i].transform, 1f, 1f);
        }
        

    }

    //This will clear the list and re-add everything if the amount of players changes suddenly during a round.
    //Im getting a gameobject instead of a transform for no real reason, i guess it just might give slightly more options on how to affect the object.
    public void RemoveTargetGroupMember(GameObject removeThis)
    {
        cinemachineTargetGroup.RemoveMember(removeThis.transform);
        for (int i = 0; i < FindObjectsOfType<Erin_UI_PlayerHealth>().Length; i++)
        {
            cinemachineTargetGroup.AddMember(GameObject.FindObjectsOfType<Erin_UI_PlayerHealth>()[i].transform, 1f, 1f);
        }
    }
}
