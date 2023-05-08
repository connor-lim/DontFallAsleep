using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public void SetMaxHealth(float amount)
    {
        slider.maxValue = amount;
        slider.value = amount;
    }

    public void SetHealth(float amount)
    {
        slider.value = amount;
    }
}
