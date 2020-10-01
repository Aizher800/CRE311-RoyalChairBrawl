using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using _InputTest.Entity.Scripts.Input.Monobehaviours;

    public class PlayerInputCustom : MonoBehaviour
{

    [SerializeField] string Horizontal, Vertical, Attack, Block, Jump;
    // Start is called before the first frame update
    CharacterInput charInput;

    private void Start()
    {
        charInput = GetComponent<CharacterInput>();
    }
    private void Update()
    {

        if (Input.GetButton(Horizontal))
        {
           // charInput.OnMoveEvent(Input.GetAxis(Horizontal));

        }

    }


}
