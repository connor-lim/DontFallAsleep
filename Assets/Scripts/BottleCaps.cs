using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BottleCaps : MonoBehaviour
{
    int current_bottlecaps;

    public Player player;

    public TextMeshProUGUI bottlecapText;

    void Start()
    {
        current_bottlecaps = player.GetCurrentBottlecaps();
    }

    void Update()
    {
        current_bottlecaps = player.GetCurrentBottlecaps();
        bottlecapText.text = ("Bottle Caps: ") + current_bottlecaps.ToString("0");
    }
}
