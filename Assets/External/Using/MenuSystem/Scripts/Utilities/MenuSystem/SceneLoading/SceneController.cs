using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public UnityEvent preloadSceneEvent;
    public UnityEvent postloadSceneEvent;

    public bool unsubscribeOnDisable = true;
    public float minimumLoadTime = 0.5f;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        if (unsubscribeOnDisable) SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    #region LoadSceneWithName

    public void OnLoadScene(string sceneName)
    {
        Debug.Log("Pressed");
        StartCoroutine(LoadScene(sceneName));
    }

    IEnumerator LoadScene(string sceneName)
    {
        preloadSceneEvent?.Invoke();

        yield return new WaitForSeconds(minimumLoadTime);

        SceneManager.LoadScene(sceneName);

        yield return null;
    }

    #endregion

    #region LoadSceneWithIndex

    public void OnLoadScene(int index)
    {
        StartCoroutine(LoadScene(index));
    }

    IEnumerator LoadScene(int index)
    {
        preloadSceneEvent?.Invoke();

        yield return new WaitForSeconds(minimumLoadTime);

        SceneManager.LoadScene(index);


        yield return null;
    }

    #endregion

    public void OnReloadCurrentScene()
    {
        OnLoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        postloadSceneEvent?.Invoke();
    }

    public void Log(string message)
    {
        Debug.Log($"{SceneManager.GetActiveScene().name}: {message}");
    }
}
