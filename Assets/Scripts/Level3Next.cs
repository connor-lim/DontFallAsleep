using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3Next : MonoBehaviour
{
    public GameObject pauseMenu;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(5);
    }
}
