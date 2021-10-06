using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenething : MonoBehaviour
{

    public void RestartLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Week2Scene", LoadSceneMode.Single);
        Time.timeScale = 1;
    }
}
