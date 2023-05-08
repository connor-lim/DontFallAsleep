using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float maxHealth = 50f;
    public float currentHealth;
    public float maxStamina = 100f;
    public float currentStamina;
    public int bottlecap_num;
    public int energydrinks;
    public float stamina_drain = 0.09f;

    public StaminaBar staminaBar;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentStamina = maxStamina;
        currentHealth = maxHealth;
        staminaBar.SetMaxStamina(maxStamina);
        healthBar.SetMaxHealth(maxHealth);

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale > 0)
        {
            currentStamina -= stamina_drain;
            staminaBar.SetStamina(currentStamina);
        }

        if (currentStamina <= 0)
        {
            Die();
        }

        if (currentHealth <= 0)
        {
            Die();
        }

        if (Input.GetKeyDown(KeyCode.Q) && energydrinks >= 1)
        {
            ReplenishEnergy();
            energydrinks--;
        }
    }

    void ReplenishEnergy()
    {
        currentStamina = maxStamina;
        staminaBar.SetStamina(currentStamina);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BottleCap")
        {
            bottlecap_num++;
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Fireball")
        {
            currentHealth -= 10f;
            healthBar.SetHealth(currentHealth);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy1")
        {
            currentHealth -= 0.1f;
            healthBar.SetHealth(currentHealth);
        }
        if (other.gameObject.tag == "Enemy2")
        {
            currentHealth -= 0.3f;
            healthBar.SetHealth(currentHealth);
        }
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public float GetCurrentStamina()
    {
        return currentStamina;
    }

    public int GetCurrentBottlecaps()
    {
        return bottlecap_num;
    }

    public int GetCurrentEnergyDrinks()
    {
        return energydrinks;
    }

    public void IncreaseEnergyDrinks()
    {
        if (bottlecap_num >= 10)
        {
            energydrinks++;
            bottlecap_num -= 10;
        }
    }

    void Die()
    {
        SceneManager.LoadScene(7);
    }

}
