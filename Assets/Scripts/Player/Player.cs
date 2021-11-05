using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public PlayerData data;
    public PlayerInputHandler inputHandler;
    public GameObject MenuUI;
    public DialogueSystem dialogueUI;
    PlayerMovement playerMovement;
    CharacterController charController;
    Health health;

    public Dictionary<int, Interactable> interactables = new Dictionary<int, Interactable>();
    public Inventory inventory;

    public UnityEvent<float> OnPlayerGainXP;
    public UnityEvent<float> OnPlayerResourceChange;
    public UnityEvent<Interactable> OnInteract;
    /// <summary>
    /// Use this for distances and raycasts.
    /// </summary>
    public Transform centerMassTransform;

    public enum PlayerClass
    {
        Rogue, Knight, Wizard
    }

    public enum ResourceType
    {
        Mana, Stamina
    }



    public float AbilityResource { get { return abilityResource; }}
    public float AbilityResourceMax { get { return resourceMax; } }
    float resourceMax = 100f;
    float abilityResource;
    
    public float resourceGainPerSec = 5f;
    public bool regenResource = true;

    //Checks if the player has a certain amount of resource
    public bool HasResource(float cost)
    {
        return (abilityResource >= cost);
    }

    /// <summary>
    /// Checks if the player has a percent of health
    /// </summary>
    /// <param name="percent">0-1 percent</param>
    /// <returns></returns>
    public bool HasPercentHealth(float percent)
    {
        if (health == null) Debug.LogError("Player has null health component. Check if it's dragged in");
        return Utility.HasPercent(percent, health.Current, health.max);
    } 
    public bool HasPercentResource(float percent)
    {
        
        return Utility.HasPercent(percent, abilityResource, resourceMax);
    }



    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        health = GetComponent<Health>();
        if (inputHandler == null) inputHandler = GetComponent<PlayerInputHandler>();
        inputHandler.OnInteract_Performed.AddListener(Interact);
        inputHandler.OnMenuButton_Performed.AddListener(OnToggleMenu);
        OnPlayerGainXP.AddListener(data.OnGainXP);
        OnPlayerResourceChange.AddListener(OnUpdateResource);
        abilityResource = resourceMax;
    }

    void OnUpdateResource(float change)
    {
        
        abilityResource = Mathf.Max(Mathf.Min(abilityResource + change, resourceMax), 0);
    }
    
    public void OnGainXP(float XP)
    {
        data.totalXP += XP;
        OnPlayerGainXP.Invoke(XP);
        //CREATE POP UP ABOVE PLAYER
        Debug.Log(data.totalXP);
    }

    void OnToggleMenu()
    {
        MenuUI?.SetActive(!MenuUI.activeInHierarchy);
    }

    private void Update()
    {
        if (regenResource && abilityResource <= resourceMax)
        {
            OnPlayerResourceChange.Invoke(resourceGainPerSec * Time.deltaTime);
        }
    }

    //INTERACTIONS
    void Interact()
    {
        if (interactables.Count != 0)
        {
            Interactable interacted = Utility.GetNearestInList<Interactable>(transform.position, interactables.Values.ToList());
            //adds item to inventory if the interactable is an item
            if(interacted.data.interactType == InteractableData.interactableType.Item && inventory.TryAdd((ItemData)(interacted.data)))
            {
                interactables.Remove(interacted.id);
            }

            interacted.Interact(this);
            OnInteract.Invoke(interacted);


        }
    }

    public void OnEnterInteraction(Interactable interactable)
    {
        Debug.Log($"Entered interaction range of {interactable.data.name}");
        if(!interactables.ContainsKey(interactable.id)) interactables.Add(interactable.id, interactable);
    }

    public void OnExitInteraction(Interactable interactable)
    {
        interactables.Remove(interactable.id);
        //Debug.Log($"Exited interaction range of {interactable.data.name}");
    }
}
