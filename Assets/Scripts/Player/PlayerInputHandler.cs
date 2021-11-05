using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    PlayerControls controls;
    public Camera cam;

    public float raycastRange = 1000f;

    public bool MK_Active = true;
    public bool GP_Active;


    public Vector2 Movement { get { return movement; } }
    Vector2 movement;

    public Vector2 StickRotation { get { return stickRotation; } }
    Vector2 stickRotation;
    
    public Vector2 MousePos { get { return mousePos; } }
    Vector2 mousePos;

    public RaycastHit MouseRayCastHitInfo { get { return hitinfo; } }
    RaycastHit hitinfo;

    public UnityEvent OnBasicAttackBtn_Down;
    public UnityEvent OnBasicAttackBtn_Up;
    public UnityEvent OnRolling_Performed;
    public UnityEvent OnInteract_Performed;
    public UnityEvent OnMenuButton_Performed;
    public UnityEvent<GameObject> OnRaycastObjectHitChanged;

    GameObject current;

    private void Awake()
    {
        //Create a PlayerControls
        controls = new PlayerControls();
        
        //Start with Mouse & KeyboardControls
        OnMKControlsActivate();
        //Mouse and Keyboard Controls
        controls.MKGameplay.Movement.performed += ctx => movement = ctx.ReadValue<Vector2>();
        controls.MKGameplay.Movement.canceled += ctx => movement = Vector2.zero;

        controls.MKMenu.Mouse.performed += ctx => mousePos = ctx.ReadValue<Vector2>();
        controls.MKGameplay.MouseTracking.performed += ctx => mousePos = ctx.ReadValue<Vector2>();

        controls.MKGameplay.PrimaryAttack.performed += PrimaryAttack_performed;
        controls.MKGameplay.Rolling.performed += Rolling_performed;
        controls.MKGameplay.Interact.performed += Interact_performed; 
        controls.MKGameplay.MenuButton.performed += MenuButton_performed;
        controls.MKMenu.ExitMenu.performed += ExitMenu_performed;

    }

    private void Update()
    {
        
        Ray ray = cam.ScreenPointToRay(mousePos);
        if (Physics.Raycast(ray, out RaycastHit hitinfo, raycastRange))
        {
            this.hitinfo = hitinfo;
            if (hitinfo.collider.gameObject != current)
            {
                current = hitinfo.collider.gameObject;
                OnRaycastObjectHitChanged.Invoke(current);
            }
            
        }
        //Debug.Log(hitinfo.collider != null ? hitinfo.collider.gameObject.name : "Nothing hit.");
    }

    private void ExitMenu_performed(InputAction.CallbackContext obj)
    {
        OnMKControlsActivate();
        OnMenuButton_Performed.Invoke();
    }

    private void MenuButton_performed(InputAction.CallbackContext obj)
    {
        OnMenuControlsActivate();
        
        OnMenuButton_Performed.Invoke();
    }

    private void Interact_performed(InputAction.CallbackContext obj)
    {
        OnInteract_Performed.Invoke();
    }

    private void Rolling_performed(InputAction.CallbackContext obj)
    {
        OnRolling_Performed.Invoke();
    }

    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
    private void PrimaryAttack_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        //Debug.Log("Basic Attack done in handler");
        OnBasicAttackBtn_Down.Invoke();
    }

    void DisableControls()
    {
        controls.MKMenu.Disable();
        controls.Gameplay.Disable();
        controls.MKGameplay.Disable();
    }
    void OnMKControlsActivate()
    {

        DisableControls();
        controls.MKGameplay.Enable();
        MK_Active = true;
        GP_Active = false;
    }

    void OnGamepadControlsActivate()
    {
        DisableControls();
        controls.Gameplay.Enable();
        GP_Active = true;
        MK_Active = false;

    }

    void OnMenuControlsActivate()
    {
        //turn everything off but menu, duh
        DisableControls();
        controls.MKMenu.Enable();
    }
}
