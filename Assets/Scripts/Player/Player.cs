using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public PlayerData PlayerData;
    public PlayerInputHandler inputHandler;
    public GameObject MenuUI;
    PlayerMovement playerMovement;
    CharacterController charController;
    Health health;

    public Dictionary<int, Interactable> interactables = new Dictionary<int, Interactable>();
    public Inventory inventory;

    public UnityEvent<float> OnPlayerGainXP;

    public enum PlayerClass
    {
        Rogue, Knight, Wizard
    }


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
        inputHandler.OnMenuButton_Performed.AddListener(OnToggleMenu);
        OnPlayerGainXP.AddListener(PlayerData.OnGainXP);
    }

    
    public void OnGainXP(float XP)
    {
        PlayerData.totalXP += XP;
        OnPlayerGainXP.Invoke(XP);
        //CREATE POP UP ABOVE PLAYER
        Debug.Log(PlayerData.totalXP);
    }

    void OnToggleMenu()
    {
        MenuUI?.SetActive(!MenuUI.activeInHierarchy);
    }

    //INTERACTIONS

    void Interact()
    {
        if (interactables.Count != 0)
        {
            Interactable interacted = Utility.GetNearestInList<Interactable>(transform.position, interactables.Values.ToList());
            if(interacted.data.interactType == InteractableData.interactableType.Item && inventory.TryAdd((ItemData)(interacted.data)))
            {
                interactables.Remove(interacted.id);
                //MAKE INTERACT TAKE A PLAYER PARAM
                interacted.Interact();
            }
            else
            {
                interacted.Interact();

            }

        }
    }

    public void OnEnterInteraction(Interactable interactable)
    {
        if(!interactables.ContainsKey(interactable.id)) interactables.Add(interactable.id, interactable);
        //Debug.Log($"Entered interaction range of {interactable.data.name}");
    }

    public void OnExitInteraction(Interactable interactable)
    {
        interactables.Remove(interactable.id);
        //Debug.Log($"Exited interaction range of {interactable.data.name}");
    }
}
