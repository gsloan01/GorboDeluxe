using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public PlayerData PlayerData;
    public PlayerInputHandler inputHandler;
    PlayerMovement playerMovement;
    CharacterController charController;
    Health health;

    public UnityEvent<float> OnPlayerGainXP;

    #region variables
    public float AbilityResource { get { return abilityResource; } }
    float resourceMax = 100f;
    float abilityResource;
    
    public float resourceGainPerSec = 5f;
    public bool regenResource = true;

    #endregion


    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        health = GetComponent<Health>();
        if (inputHandler == null) inputHandler = GetComponent<PlayerInputHandler>();
    }

    public void OnGainXP(float XP)
    {
        PlayerData.totalXP += XP;
        OnPlayerGainXP.Invoke(XP);
        Debug.Log(PlayerData.totalXP);
    }
}
