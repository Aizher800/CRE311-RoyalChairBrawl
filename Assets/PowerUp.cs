using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PowerUpType
{
    HEALING,
    ENERGY,
    SPEED,
    DAMAGE,
    JUMP

}
[System.Serializable]
public class PowerUpValues
{
    //type of powerup
    [SerializeField] public PowerUpType type;


    //Healing value
    [SerializeField] public int _healingValue;

    //Energy value
    [SerializeField] public int _energyValue;

    [SerializeField] public float _jumpBoost;
    //damage boost
    [SerializeField] public float _damageBoost;

    //speed boost
    [SerializeField] public float _speedBoost;

    //boost duration
    [SerializeField] public float _boostDuration;

}
public class PowerUp : GroundItem
{
   public PowerUpValues _powerUpValues;
    public override void Interact(Matt_SM_PlayerStateInfo _owner)
    {
        _owner.GetComponent<PowerUpManager>().PickUpPowerUp(this);
      //  _owner.GetComponent<Erin_UI_PlayerHealth>().RemoveHealth(_healingValue, _owner.PSI_inputNum);
        Destroy(gameObject);
    }

    // Start is called before the first frame update

}
