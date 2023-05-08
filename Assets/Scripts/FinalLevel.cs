using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalLevel : MonoBehaviour
{
    public GameObject boss;

    void Update()
    {
        if (boss.activeSelf == false)
        {
            SceneManager.LoadScene(6);
        }
    }
}
