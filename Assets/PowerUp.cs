using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : GroundItem
{

    [SerializeField] int _healingValue;

    [SerializeField] int _energyValue;
    public override void Interact(Matt_SM_PlayerStateInfo _owner)
    {
        _owner.GetComponent<Erin_UI_PlayerHealth>().RemoveHealth(_healingValue, _owner.PSI_inputNum);
        Destroy(gameObject);
    }

    // Start is called before the first frame update

}
