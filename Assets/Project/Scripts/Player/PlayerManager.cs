using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    public UnityEvent<Player> OnPlayerEnter;
    public UnityEvent<Player> OnPlayerLeave;


    public GameObject player;
    public List<GameObject> players;

    public void AddPlayer(Player addedPlayer)
    {
        players.Add(addedPlayer.gameObject);
    }

    public void RemovePlayer(Player leftPlayer)
    {
        players.Remove(leftPlayer.gameObject);

    }
}
