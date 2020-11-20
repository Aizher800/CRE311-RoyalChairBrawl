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
                break;
            case PowerUpType.SPEED:
                break;
            case PowerUpType.DAMAGE:
                break;
            default:
                break;
        }


    }
}
