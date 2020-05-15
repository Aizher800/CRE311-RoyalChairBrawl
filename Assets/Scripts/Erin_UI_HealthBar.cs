using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Erin_UI_HealthBar : MonoBehaviour
{
    //N.B. we will need to hide the health bar during the pause menu, but keep it's value for when unpaused.

    public Slider slider;
    public Gradient gradient;   //GRADIENT - To change the colour of the bar according to hp remaining.
    public Image fill;          //GRADIENT


    void Start()
    {

    }


    void Update()
    {

    }
    

        public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;  //sets slider to start at max health

       fill.color = gradient.Evaluate(1f); //GRADIENT - Max health colour, green.
    }


    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue); //GRADIENT = normalised, so it goes between 0 & 1.
    }
}
