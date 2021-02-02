using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TargetGroupScript : MonoBehaviour
{

    [SerializeField] CinemachineTargetGroup cinemachineTargetGroup;



    // Start is called before the first frame update
    void Start()
    {
        cinemachineTargetGroup = FindObjectOfType<CinemachineTargetGroup>();
        cinemachineTargetGroup.AddMember(gameObject.transform, 1f, 1f);
    }

    // Update is called once per frame
    private void OnDestroy()
    {
        cinemachineTargetGroup.RemoveMember(gameObject.transform);
    }
}
