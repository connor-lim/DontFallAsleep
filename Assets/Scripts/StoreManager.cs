using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{

    public GameObject shop;
    public Player player;

    void Start()
    {
        shop.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            shop.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0.0f;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            shop.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void ExitStore()
    {
        Time.timeScale = 1f;
    }
}
