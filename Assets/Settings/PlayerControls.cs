// GENERATED AUTOMATICALLY FROM 'Assets/Settings/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""b111a0b6-b22f-460e-9a17-b4c21bf4abe5"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""a98cf362-7a9d-4bdd-bdcc-dac72db85edb"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotation"",
                    ""type"": ""Value"",
                    ""id"": ""5b2cbda1-ff97-4ade-b1a0-a6bd40da91ae"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""88555048-ce53-498c-9597-ac487d647608"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""efac2604-a2cf-4161-89f5-7adae7da4ef4"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MKGameplay"",
            ""id"": ""064c63ae-ee99-4238-b1d7-b5df9165880d"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""d808071b-196d-438b-8970-54c3fc002928"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseTracking"",
                    ""type"": ""Value"",
                    ""id"": ""5429929d-0b91-46ac-9708-44bc29a04ba6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PrimaryAttack"",
                    ""type"": ""Button"",
                    ""id"": ""248161bb-fa5e-4d1d-acbd-54f0e0b6c8e3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rolling"",
                    ""type"": ""Button"",
                    ""id"": ""560587e5-f2e6-460f-9ab9-d7f6f1910ff3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""a120fcf9-8228-4521-bcfe-2475f6ce782a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MenuButton"",
                    ""type"": ""Button"",
                    ""id"": ""f4013469-0820-4572-9bc7-7e9227f8cef9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightClick"",
                    ""type"": ""Button"",
                    ""id"": ""969a6ce4-777c-4002-a1e1-1675593d351f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Q"",
                    ""type"": ""Button"",
                    ""id"": ""cf829cb7-9bbc-42b9-af2b-9249080e398c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""d3d5c369-cf72-4537-a14f-eadfa84acf30"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""78e4b64c-8b83-4ebc-857f-7ef15fb27348"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c721edde-4566-4c62-9d23-4e2cec4f8055"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""cfcbf90a-28a9-452c-8318-2c9dcb8b8633"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7bd34a64-37af-4689-bfee-1c3f4166927d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""2dbd6d87-51b5-46c1-b0d5-23fe65590152"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseTracking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2235198d-c84e-4773-a0fe-3af31da65574"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""PrimaryAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1fc5b3d7-b172-477d-a7b0-0d9ba5ca9497"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""Rolling"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8bce9d3b-e512-4b6e-acfd-fbae85978e6c"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8a098616-98ad-47cc-8576-73a9f2cf5268"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""MenuButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a18e3939-f766-40be-9ce2-4538004f3aa2"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""MenuButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c7d4f78-1388-45b1-9c0b-b4975ec9c2c6"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""RightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3173282c-05d6-4aec-9d4a-03f36d2e8244"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""Q"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MKMenu"",
            ""id"": ""a125cd7d-9868-4d20-8f7a-5a0c34b23c03"",
            ""actions"": [
                {
                    ""name"": ""ExitMenu"",
                    ""type"": ""Button"",
                    ""id"": ""3f226cb6-b4f3-4b24-bea6-f7af230e78ee"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Mouse"",
                    ""type"": ""Value"",
                    ""id"": ""91491161-6f12-48dd-8a43-2eb8c5f8ba0b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left Click"",
                    ""type"": ""Button"",
                    ""id"": ""cc0f94be-daab-4c7f-9e08-d211a47249f5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right Click"",
                    ""type"": ""Button"",
                    ""id"": ""065fe3d2-266f-4225-a403-aee9fa76a6cc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e04927a7-c3b8-4628-b887-613877542f68"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""ExitMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9169485d-f081-4610-8f8f-ffa6b236a1bd"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""ExitMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a6b4caf6-1e8a-4aa3-8ac6-ae0a361e224e"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""Mouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7623108b-9fb3-44c4-b686-528bf397dc22"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""Left Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb335b96-6d4c-4c34-af89-61fe4dd9d57c"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""Right Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""MouseKeyboard"",
            ""bindingGroup"": ""MouseKeyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<DualShockGamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<SwitchProControllerHID>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Movement = m_Gameplay.FindAction("Movement", throwIfNotFound: true);
        m_Gameplay_Rotation = m_Gameplay.FindAction("Rotation", throwIfNotFound: true);
        // MKGameplay
        m_MKGameplay = asset.FindActionMap("MKGameplay", throwIfNotFound: true);
        m_MKGameplay_Movement = m_MKGameplay.FindAction("Movement", throwIfNotFound: true);
        m_MKGameplay_MouseTracking = m_MKGameplay.FindAction("MouseTracking", throwIfNotFound: true);
        m_MKGameplay_PrimaryAttack = m_MKGameplay.FindAction("PrimaryAttack", throwIfNotFound: true);
        m_MKGameplay_Rolling = m_MKGameplay.FindAction("Rolling", throwIfNotFound: true);
        m_MKGameplay_Interact = m_MKGameplay.FindAction("Interact", throwIfNotFound: true);
        m_MKGameplay_MenuButton = m_MKGameplay.FindAction("MenuButton", throwIfNotFound: true);
        m_MKGameplay_RightClick = m_MKGameplay.FindAction("RightClick", throwIfNotFound: true);
        m_MKGameplay_Q = m_MKGameplay.FindAction("Q", throwIfNotFound: true);
        // MKMenu
        m_MKMenu = asset.FindActionMap("MKMenu", throwIfNotFound: true);
        m_MKMenu_ExitMenu = m_MKMenu.FindAction("ExitMenu", throwIfNotFound: true);
        m_MKMenu_Mouse = m_MKMenu.FindAction("Mouse", throwIfNotFound: true);
        m_MKMenu_LeftClick = m_MKMenu.FindAction("Left Click", throwIfNotFound: true);
        m_MKMenu_RightClick = m_MKMenu.FindAction("Right Click", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Movement;
    private readonly InputAction m_Gameplay_Rotation;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Gameplay_Movement;
        public InputAction @Rotation => m_Wrapper.m_Gameplay_Rotation;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Rotation.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotation;
                @Rotation.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotation;
                @Rotation.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotation;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Rotation.started += instance.OnRotation;
                @Rotation.performed += instance.OnRotation;
                @Rotation.canceled += instance.OnRotation;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // MKGameplay
    private readonly InputActionMap m_MKGameplay;
    private IMKGameplayActions m_MKGameplayActionsCallbackInterface;
    private readonly InputAction m_MKGameplay_Movement;
    private readonly InputAction m_MKGameplay_MouseTracking;
    private readonly InputAction m_MKGameplay_PrimaryAttack;
    private readonly InputAction m_MKGameplay_Rolling;
    private readonly InputAction m_MKGameplay_Interact;
    private readonly InputAction m_MKGameplay_MenuButton;
    private readonly InputAction m_MKGameplay_RightClick;
    private readonly InputAction m_MKGameplay_Q;
    public struct MKGameplayActions
    {
        private @PlayerControls m_Wrapper;
        public MKGameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_MKGameplay_Movement;
        public InputAction @MouseTracking => m_Wrapper.m_MKGameplay_MouseTracking;
        public InputAction @PrimaryAttack => m_Wrapper.m_MKGameplay_PrimaryAttack;
        public InputAction @Rolling => m_Wrapper.m_MKGameplay_Rolling;
        public InputAction @Interact => m_Wrapper.m_MKGameplay_Interact;
        public InputAction @MenuButton => m_Wrapper.m_MKGameplay_MenuButton;
        public InputAction @RightClick => m_Wrapper.m_MKGameplay_RightClick;
        public InputAction @Q => m_Wrapper.m_MKGameplay_Q;
        public InputActionMap Get() { return m_Wrapper.m_MKGameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MKGameplayActions set) { return set.Get(); }
        public void SetCallbacks(IMKGameplayActions instance)
        {
            if (m_Wrapper.m_MKGameplayActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_MKGameplayActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_MKGameplayActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_MKGameplayActionsCallbackInterface.OnMovement;
                @MouseTracking.started -= m_Wrapper.m_MKGameplayActionsCallbackInterface.OnMouseTracking;
                @MouseTracking.performed -= m_Wrapper.m_MKGameplayActionsCallbackInterface.OnMouseTracking;
                @MouseTracking.canceled -= m_Wrapper.m_MKGameplayActionsCallbackInterface.OnMouseTracking;
                @PrimaryAttack.started -= m_Wrapper.m_MKGameplayActionsCallbackInterface.OnPrimaryAttack;
                @PrimaryAttack.performed -= m_Wrapper.m_MKGameplayActionsCallbackInterface.OnPrimaryAttack;
                @PrimaryAttack.canceled -= m_Wrapper.m_MKGameplayActionsCallbackInterface.OnPrimaryAttack;
                @Rolling.started -= m_Wrapper.m_MKGameplayActionsCallbackInterface.OnRolling;
                @Rolling.performed -= m_Wrapper.m_MKGameplayActionsCallbackInterface.OnRolling;
                @Rolling.canceled -= m_Wrapper.m_MKGameplayActionsCallbackInterface.OnRolling;
                @Interact.started -= m_Wrapper.m_MKGameplayActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_MKGameplayActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_MKGameplayActionsCallbackInterface.OnInteract;
                @MenuButton.started -= m_Wrapper.m_MKGameplayActionsCallbackInterface.OnMenuButton;
                @MenuButton.performed -= m_Wrapper.m_MKGameplayActionsCallbackInterface.OnMenuButton;
                @MenuButton.canceled -= m_Wrapper.m_MKGameplayActionsCallbackInterface.OnMenuButton;
                @RightClick.started -= m_Wrapper.m_MKGameplayActionsCallbackInterface.OnRightClick;
                @RightClick.performed -= m_Wrapper.m_MKGameplayActionsCallbackInterface.OnRightClick;
                @RightClick.canceled -= m_Wrapper.m_MKGameplayActionsCallbackInterface.OnRightClick;
                @Q.started -= m_Wrapper.m_MKGameplayActionsCallbackInterface.OnQ;
                @Q.performed -= m_Wrapper.m_MKGameplayActionsCallbackInterface.OnQ;
                @Q.canceled -= m_Wrapper.m_MKGameplayActionsCallbackInterface.OnQ;
            }
            m_Wrapper.m_MKGameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @MouseTracking.started += instance.OnMouseTracking;
                @MouseTracking.performed += instance.OnMouseTracking;
                @MouseTracking.canceled += instance.OnMouseTracking;
                @PrimaryAttack.started += instance.OnPrimaryAttack;
                @PrimaryAttack.performed += instance.OnPrimaryAttack;
                @PrimaryAttack.canceled += instance.OnPrimaryAttack;
                @Rolling.started += instance.OnRolling;
                @Rolling.performed += instance.OnRolling;
                @Rolling.canceled += instance.OnRolling;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @MenuButton.started += instance.OnMenuButton;
                @MenuButton.performed += instance.OnMenuButton;
                @MenuButton.canceled += instance.OnMenuButton;
                @RightClick.started += instance.OnRightClick;
                @RightClick.performed += instance.OnRightClick;
                @RightClick.canceled += instance.OnRightClick;
                @Q.started += instance.OnQ;
                @Q.performed += instance.OnQ;
                @Q.canceled += instance.OnQ;
            }
        }
    }
    public MKGameplayActions @MKGameplay => new MKGameplayActions(this);

    // MKMenu
    private readonly InputActionMap m_MKMenu;
    private IMKMenuActions m_MKMenuActionsCallbackInterface;
    private readonly InputAction m_MKMenu_ExitMenu;
    private readonly InputAction m_MKMenu_Mouse;
    private readonly InputAction m_MKMenu_LeftClick;
    private readonly InputAction m_MKMenu_RightClick;
    public struct MKMenuActions
    {
        private @PlayerControls m_Wrapper;
        public MKMenuActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @ExitMenu => m_Wrapper.m_MKMenu_ExitMenu;
        public InputAction @Mouse => m_Wrapper.m_MKMenu_Mouse;
        public InputAction @LeftClick => m_Wrapper.m_MKMenu_LeftClick;
        public InputAction @RightClick => m_Wrapper.m_MKMenu_RightClick;
        public InputActionMap Get() { return m_Wrapper.m_MKMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MKMenuActions set) { return set.Get(); }
        public void SetCallbacks(IMKMenuActions instance)
        {
            if (m_Wrapper.m_MKMenuActionsCallbackInterface != null)
            {
                @ExitMenu.started -= m_Wrapper.m_MKMenuActionsCallbackInterface.OnExitMenu;
                @ExitMenu.performed -= m_Wrapper.m_MKMenuActionsCallbackInterface.OnExitMenu;
                @ExitMenu.canceled -= m_Wrapper.m_MKMenuActionsCallbackInterface.OnExitMenu;
                @Mouse.started -= m_Wrapper.m_MKMenuActionsCallbackInterface.OnMouse;
                @Mouse.performed -= m_Wrapper.m_MKMenuActionsCallbackInterface.OnMouse;
                @Mouse.canceled -= m_Wrapper.m_MKMenuActionsCallbackInterface.OnMouse;
                @LeftClick.started -= m_Wrapper.m_MKMenuActionsCallbackInterface.OnLeftClick;
                @LeftClick.performed -= m_Wrapper.m_MKMenuActionsCallbackInterface.OnLeftClick;
                @LeftClick.canceled -= m_Wrapper.m_MKMenuActionsCallbackInterface.OnLeftClick;
                @RightClick.started -= m_Wrapper.m_MKMenuActionsCallbackInterface.OnRightClick;
                @RightClick.performed -= m_Wrapper.m_MKMenuActionsCallbackInterface.OnRightClick;
                @RightClick.canceled -= m_Wrapper.m_MKMenuActionsCallbackInterface.OnRightClick;
            }
            m_Wrapper.m_MKMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ExitMenu.started += instance.OnExitMenu;
                @ExitMenu.performed += instance.OnExitMenu;
                @ExitMenu.canceled += instance.OnExitMenu;
                @Mouse.started += instance.OnMouse;
                @Mouse.performed += instance.OnMouse;
                @Mouse.canceled += instance.OnMouse;
                @LeftClick.started += instance.OnLeftClick;
                @LeftClick.performed += instance.OnLeftClick;
                @LeftClick.canceled += instance.OnLeftClick;
                @RightClick.started += instance.OnRightClick;
                @RightClick.performed += instance.OnRightClick;
                @RightClick.canceled += instance.OnRightClick;
            }
        }
    }
    public MKMenuActions @MKMenu => new MKMenuActions(this);
    private int m_MouseKeyboardSchemeIndex = -1;
    public InputControlScheme MouseKeyboardScheme
    {
        get
        {
            if (m_MouseKeyboardSchemeIndex == -1) m_MouseKeyboardSchemeIndex = asset.FindControlSchemeIndex("MouseKeyboard");
            return asset.controlSchemes[m_MouseKeyboardSchemeIndex];
        }
    }
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnRotation(InputAction.CallbackContext context);
    }
    public interface IMKGameplayActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnMouseTracking(InputAction.CallbackContext context);
        void OnPrimaryAttack(InputAction.CallbackContext context);
        void OnRolling(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnMenuButton(InputAction.CallbackContext context);
        void OnRightClick(InputAction.CallbackContext context);
        void OnQ(InputAction.CallbackContext context);
    }
    public interface IMKMenuActions
    {
        void OnExitMenu(InputAction.CallbackContext context);
        void OnMouse(InputAction.CallbackContext context);
        void OnLeftClick(InputAction.CallbackContext context);
        void OnRightClick(InputAction.CallbackContext context);
    }
}
