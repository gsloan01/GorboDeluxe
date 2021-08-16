using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    #region Managers
    PlayerManager playerManager;
    #endregion

    #region Instance
    public static GameSettings Instance { get { return instance; } }
    static GameSettings instance;

    private void Awake()
    {
        instance = this;
        playerManager = PlayerManager.Instance;
    }
    #endregion
    public bool debug;

    public bool dayNightCycling = false;
    public bool daytime = true;

    public bool postProcessing = true;

    public float gameSpeed = 1.0f;

    private void Update()
    {
    }

}
