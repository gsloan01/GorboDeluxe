using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader: MonoBehaviour
{
    public string TestSceneName;

    public void RestartLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(TestSceneName, LoadSceneMode.Single);
        Time.timeScale = 1;
    }
}
