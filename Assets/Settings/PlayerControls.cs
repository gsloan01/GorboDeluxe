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
                    ""expectedControlType"": """",
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
                },
                {
                    ""name"": ""Skill1"",
                    ""type"": ""Button"",
                    ""id"": ""6ce359f6-5624-4a51-82b0-975de0e10a56"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Skill2"",
                    ""type"": ""Button"",
                    ""id"": ""c0f26f9a-188d-4737-b9c0-ebc0a1685d0e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Skill3"",
                    ""type"": ""Button"",
                    ""id"": ""e5cfc774-effe-49d0-ba2d-80f3a00c5a94"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Skill4"",
                    ""type"": ""Button"",
                    ""id"": ""1f8eedb2-5d04-47e8-a42e-92744c9dd625"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Skill5"",
                    ""type"": ""Button"",
                    ""id"": ""6e321550-e0b8-4cf6-ac17-32627309647c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Skill6"",
                    ""type"": ""Button"",
                    ""id"": ""c4db9f8d-4bce-42df-8758-37a035add3a3"",
                    ""expectedControlType"": ""Button"",
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
                    ""groups"": """",
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
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cfa15fda-eaa5-46b6-9186-e23557c8d0df"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3f826224-61c9-4466-a8a8-ee449619695b"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a16b4bcf-e485-4ad2-ab94-dc275147e0b2"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5bcd10fd-f86c-4662-9dc9-e0bd7cd62296"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d79b7983-5bda-4d75-a562-b082114783bf"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill6"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d4acd1aa-fea0-4692-a2c2-e319fcc95d5b"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill4"",
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
                    ""name"": ""New action"",
                    ""type"": ""Value"",
                    ""id"": ""d808071b-196d-438b-8970-54c3fc002928"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""828f792e-7c54-4a63-a7c8-4df68c6f5774"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Movement = m_Gameplay.FindAction("Movement", throwIfNotFound: true);
        m_Gameplay_Rotation = m_Gameplay.FindAction("Rotation", throwIfNotFound: true);
        m_Gameplay_Skill1 = m_Gameplay.FindAction("Skill1", throwIfNotFound: true);
        m_Gameplay_Skill2 = m_Gameplay.FindAction("Skill2", throwIfNotFound: true);
        m_Gameplay_Skill3 = m_Gameplay.FindAction("Skill3", throwIfNotFound: true);
        m_Gameplay_Skill4 = m_Gameplay.FindAction("Skill4", throwIfNotFound: true);
        m_Gameplay_Skill5 = m_Gameplay.FindAction("Skill5", throwIfNotFound: true);
        m_Gameplay_Skill6 = m_Gameplay.FindAction("Skill6", throwIfNotFound: true);
        // MKGameplay
        m_MKGameplay = asset.FindActionMap("MKGameplay", throwIfNotFound: true);
        m_MKGameplay_Newaction = m_MKGameplay.FindAction("New action", throwIfNotFound: true);
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
    private readonly InputAction m_Gameplay_Skill1;
    private readonly InputAction m_Gameplay_Skill2;
    private readonly InputAction m_Gameplay_Skill3;
    private readonly InputAction m_Gameplay_Skill4;
    private readonly InputAction m_Gameplay_Skill5;
    private readonly InputAction m_Gameplay_Skill6;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Gameplay_Movement;
        public InputAction @Rotation => m_Wrapper.m_Gameplay_Rotation;
        public InputAction @Skill1 => m_Wrapper.m_Gameplay_Skill1;
        public InputAction @Skill2 => m_Wrapper.m_Gameplay_Skill2;
        public InputAction @Skill3 => m_Wrapper.m_Gameplay_Skill3;
        public InputAction @Skill4 => m_Wrapper.m_Gameplay_Skill4;
        public InputAction @Skill5 => m_Wrapper.m_Gameplay_Skill5;
        public InputAction @Skill6 => m_Wrapper.m_Gameplay_Skill6;
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
                @Skill1.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSkill1;
                @Skill1.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSkill1;
                @Skill1.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSkill1;
                @Skill2.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSkill2;
                @Skill2.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSkill2;
                @Skill2.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSkill2;
                @Skill3.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSkill3;
                @Skill3.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSkill3;
                @Skill3.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSkill3;
                @Skill4.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSkill4;
                @Skill4.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSkill4;
                @Skill4.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSkill4;
                @Skill5.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSkill5;
                @Skill5.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSkill5;
                @Skill5.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSkill5;
                @Skill6.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSkill6;
                @Skill6.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSkill6;
                @Skill6.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSkill6;
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
                @Skill1.started += instance.OnSkill1;
                @Skill1.performed += instance.OnSkill1;
                @Skill1.canceled += instance.OnSkill1;
                @Skill2.started += instance.OnSkill2;
                @Skill2.performed += instance.OnSkill2;
                @Skill2.canceled += instance.OnSkill2;
                @Skill3.started += instance.OnSkill3;
                @Skill3.performed += instance.OnSkill3;
                @Skill3.canceled += instance.OnSkill3;
                @Skill4.started += instance.OnSkill4;
                @Skill4.performed += instance.OnSkill4;
                @Skill4.canceled += instance.OnSkill4;
                @Skill5.started += instance.OnSkill5;
                @Skill5.performed += instance.OnSkill5;
                @Skill5.canceled += instance.OnSkill5;
                @Skill6.started += instance.OnSkill6;
                @Skill6.performed += instance.OnSkill6;
                @Skill6.canceled += instance.OnSkill6;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // MKGameplay
    private readonly InputActionMap m_MKGameplay;
    private IMKGameplayActions m_MKGameplayActionsCallbackInterface;
    private readonly InputAction m_MKGameplay_Newaction;
    public struct MKGameplayActions
    {
        private @PlayerControls m_Wrapper;
        public MKGameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_MKGameplay_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_MKGameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MKGameplayActions set) { return set.Get(); }
        public void SetCallbacks(IMKGameplayActions instance)
        {
            if (m_Wrapper.m_MKGameplayActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_MKGameplayActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_MKGameplayActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_MKGameplayActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_MKGameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public MKGameplayActions @MKGameplay => new MKGameplayActions(this);
    public interface IGameplayActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnRotation(InputAction.CallbackContext context);
        void OnSkill1(InputAction.CallbackContext context);
        void OnSkill2(InputAction.CallbackContext context);
        void OnSkill3(InputAction.CallbackContext context);
        void OnSkill4(InputAction.CallbackContext context);
        void OnSkill5(InputAction.CallbackContext context);
        void OnSkill6(InputAction.CallbackContext context);
    }
    public interface IMKGameplayActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}
