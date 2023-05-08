using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{

    public Slider slider;
    public void SetMaxStamina(float amount)
    {
        slider.maxValue = amount;
        slider.value = amount;
    }

    public void SetStamina(float amount)
    {
        slider.value = amount;
    }
}
