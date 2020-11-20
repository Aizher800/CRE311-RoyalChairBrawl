using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickUpPowerUp(PowerUp powerUp)
    {
        switch (powerUp._powerUpValues.type)
        {
            case PowerUpType.HEALING:

                GetComponent<Erin_UI_PlayerHealth>().RemoveHealth(powerUp._powerUpValues._healingValue, GetComponent<Matt_SM_PlayerStateInfo>().PSI_inputNum);
                break;
            case PowerUpType.ENERGY:
                GetComponent<Erin_UI_PlayerHealth>().RemoveEnergy(powerUp._powerUpValues._energyValue, GetComponent<Matt_SM_PlayerStateInfo>().PSI_inputNum);
                break;
            case PowerUpType.SPEED:
                Debug.Log("SPEED POWERUP");
                GetComponent<Matt_SM_PlayerStateInfo>().Boost(powerUp);
                if (GetComponent<Matt_SM_PlayerStateInfo>() != null)
                {
                    Debug.Log("STATEINFO WAS NOT NULLLLLLLL");
                }
                break;
            case PowerUpType.JUMP:
                GetComponent<Matt_SM_PlayerStateInfo>().Boost(powerUp);
                break;
            case PowerUpType.DAMAGE:
                GetComponent<Matt_SM_PlayerStateInfo>().Boost(powerUp);
                break;
            default:
                break;
        }


    }
}
