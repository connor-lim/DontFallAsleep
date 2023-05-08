using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    float currentTime;
    public float startingTime = 120f;

    public int nextLevel;

    public Player player;

    public TextMeshProUGUI countdownText;
    void Start()
    {
        currentTime = startingTime;
    }
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        float currentHealth = player.GetCurrentHealth();
        float currentStamina = player.GetCurrentStamina();

        if (currentTime <= 0 && currentHealth > 0 && currentStamina > 0 )
        {
            currentTime = 0;
            SceneManager.LoadScene(nextLevel);
        }

        else if (currentTime == 0 && (currentHealth <= 0 || currentStamina <= 0))
        {
            SceneManager.LoadScene(7);
        }
    }
}
