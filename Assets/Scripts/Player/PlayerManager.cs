using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script takes care of keeping track of the players
public class PlayerManager : MonoBehaviour
{
    #region Instance
    public static PlayerManager Instance { get { return instance; } }
    static PlayerManager instance;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        instance = this;
    }
    #endregion

    public GameObject player;
    public GameObject[] players;
}
