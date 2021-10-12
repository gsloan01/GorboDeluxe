using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    PlayerControls controls;
    public bool MK_Active = true;
    public bool GP_Active;

    public Vector2 Movement { get { return movement; } }
    Vector2 movement;

    public Vector2 StickRotation { get { return stickRotation; } }
    Vector2 stickRotation;
    
    public Vector2 MousePos { get { return mousePos; } }
    Vector2 mousePos;

    public UnityEvent OnBasicAttackBtn_Down;
    public UnityEvent OnBasicAttackBtn_Up;

    private void Awake()
    {
        //Create a PlayerControls
        controls = new PlayerControls();
        //Start with Mouse & KeyboardControls
        OnMKControlsActivate();
        //Mouse and Keyboard Controls
        controls.MKGameplay.Movement.performed += ctx => movement = ctx.ReadValue<Vector2>();
        controls.MKGameplay.Movement.canceled += ctx => movement = Vector2.zero;

        controls.MKGameplay.MouseTracking.performed += ctx => mousePos = ctx.ReadValue<Vector2>();
        controls.MKGameplay.MouseTracking.canceled += ctx => mousePos = Vector2.zero;

        controls.MKGameplay.PrimaryAttack.performed += PrimaryAttack_performed;

        //Gamepad Controls
        controls.Gameplay.Movement.performed += ctx => movement = ctx.ReadValue<Vector2>();
        controls.Gameplay.Movement.canceled += ctx => movement = Vector2.zero;

        controls.Gameplay.Rotation.performed += ctx => stickRotation = ctx.ReadValue<Vector2>();
        controls.Gameplay.Rotation.canceled += ctx => stickRotation = Vector2.zero;


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
    }
}
