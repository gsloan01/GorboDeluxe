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

    public List<Interactable> interactables = new List<Interactable>();
    
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
        inputHandler.OnInteract_Performed.AddListener(Interact);
    }

    public void OnGainXP(float XP)
    {
        PlayerData.totalXP += XP;
        OnPlayerGainXP.Invoke(XP);
        Debug.Log(PlayerData.totalXP);
    }

    void Interact()
    {
        Utility.GetNearestInList<Interactable>(transform.position, interactables).Interact();
    }

    public void OnEnterInteraction(Interactable interactable)
    {
        interactables.Add(interactable);
        Debug.Log($"Entered interaction range of {interactable.data.name}");
    }

    public void OnExitInteraction(Interactable interactable)
    {
        interactables.Remove(interactable);
        Debug.Log($"Entered interaction range of {interactable.data.name}");
    }
}
