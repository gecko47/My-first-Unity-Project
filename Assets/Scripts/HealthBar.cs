using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // this lets us create a variable that will store our slider

public class HealthBar : MonoBehaviour
{

    private Slider slider;

    // Awake happens first
    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
   
}
