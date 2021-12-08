using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuController : MonoBehaviour
{
    public MenuController Instance { get { return instance; } }
    MenuController instance;

    public MenuPage startPage;
    public MenuPage optionsPage;
    public MenuPage creditsPage;
    public MenuPage pausePage;

    public List<MenuPage> extraPages;

    public bool lockCursor = false;
    public bool canPause = false;
    public float pauseTimeScale;

    public UnityEvent quitEvent;

    bool isPaused = false;
    float timeScale;

    void Start()
    {
        instance = this;

        OnTitle();
    }

    protected void LockCursor()
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public virtual void OnStart(string startSceneName)
    {
        canPause = true;
        LockCursor();
        OnClearPages();

        //Do this last
        SceneController sceneController = FindObjectOfType<SceneController>();
        sceneController?.OnLoadScene(startSceneName);
    }

    public virtual void OnClearPages()
    {
        startPage?.gameObject.SetActive(false);
        optionsPage?.gameObject.SetActive(false);
        creditsPage?.gameObject.SetActive(false);
        pausePage?.gameObject.SetActive(false);

        foreach (MenuPage page in extraPages)
        {
            page?.gameObject.SetActive(false);
        }
    }

    public virtual void OnBackToMainMenu(string menuSceneName)
    {
        OnTitle();

        //Do this last
        SceneController sceneController = FindObjectOfType<SceneController>();
        sceneController?.OnLoadScene(menuSceneName);
    }

    public virtual void OnTitle()
    {
        UnlockCursor();

        startPage?.gameObject.SetActive(true);
        optionsPage?.gameObject.SetActive(false);
        creditsPage?.gameObject.SetActive(false);
        pausePage?.gameObject.SetActive(false);

        foreach(MenuPage page in extraPages)
        {
            page?.gameObject.SetActive(false);
        }
    }

    public virtual void OnOptions()
    {
        UnlockCursor();

        optionsPage?.gameObject.SetActive(true);
        startPage?.gameObject.SetActive(false);
        creditsPage?.gameObject.SetActive(false);
        pausePage?.gameObject.SetActive(false);

        foreach (MenuPage page in extraPages)
        {
            page?.gameObject.SetActive(false);
        }
    }

    public virtual void OnCredits()
    {
        UnlockCursor();

        creditsPage?.gameObject.SetActive(true);
        startPage?.gameObject.SetActive(false);
        optionsPage?.gameObject.SetActive(false);
        pausePage?.gameObject.SetActive(false);

        foreach (MenuPage page in extraPages)
        {
            page?.gameObject.SetActive(false);
        }
    }

    public virtual void OnPause()
    {
        if (canPause)
        {
            if (isPaused)
            {
                Time.timeScale = timeScale;

                LockCursor();
            }
            else
            {
                timeScale = Time.timeScale;
                Time.timeScale = pauseTimeScale;

                UnlockCursor();
            }

            isPaused = !isPaused;

            pausePage?.gameObject.SetActive(isPaused);
            startPage?.gameObject.SetActive(false);
            optionsPage?.gameObject.SetActive(false);
            creditsPage?.gameObject.SetActive(false);

            foreach (MenuPage page in extraPages)
            {
                page?.gameObject.SetActive(false);
            }
        }
    }

    public virtual void OnActivatePage(string pageName)
    {
        UnlockCursor();

        startPage?.gameObject.SetActive(false);
        optionsPage?.gameObject.SetActive(false);
        creditsPage?.gameObject.SetActive(false);
        pausePage?.gameObject.SetActive(false);

        foreach (MenuPage page in extraPages)
        {
            if (page.name == pageName) page?.gameObject.SetActive(true);
            else page?.gameObject.SetActive(false);
        }
    }

    public virtual void OnQuit()
    {
        quitEvent?.Invoke();
        Application.Quit();
    }
}
