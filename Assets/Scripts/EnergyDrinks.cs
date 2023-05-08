using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EnergyDrinks : MonoBehaviour
{
    int current_energydrinks;

    public Player player;

    public TextMeshProUGUI energydrinkText;

    void Start()
    {
        current_energydrinks = player.GetCurrentEnergyDrinks();
    }

    void Update()
    {
        current_energydrinks = player.GetCurrentEnergyDrinks();
        energydrinkText.text = ("Energy Drinks: ") + current_energydrinks.ToString("0");
    }
}
