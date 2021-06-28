// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

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
            ""name"": ""Hand"",
            ""id"": ""84ff85a2-2a12-46e8-a843-0877d2a2e93b"",
            ""actions"": [
                {
                    ""name"": ""Shift"",
                    ""type"": ""Button"",
                    ""id"": ""5f27bfdc-edcc-4288-b7e7-55fa40acbc68"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PlayCard"",
                    ""type"": ""Button"",
                    ""id"": ""2b9078b7-ba53-46d6-baef-0d7fb0558c13"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""e4cc3072-095e-4a47-b5e4-ee06e6f96b1b"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shift"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""c2e286c0-0412-44b2-a643-be3def76acd5"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shift"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""bc9dc645-909f-42d3-b05d-89e7da51954b"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shift"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d57dd48a-e800-4831-bf31-23a6b0c39df3"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayCard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player"",
            ""id"": ""8d95e816-021e-4d7f-a0ff-0845e93d287e"",
            ""actions"": [
                {
                    ""name"": ""Attack.Interact"",
                    ""type"": ""Button"",
                    ""id"": ""3b5ae08d-64a7-40e1-b9db-edba8c2b5bb1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Block"",
                    ""type"": ""Button"",
                    ""id"": ""16d2d962-5dbf-4ac9-b5dc-ab9069135c2c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""508f5333-b199-4186-a86f-1efa1aba7ada"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""df03743d-8893-49c8-8f0b-d1206ade2c01"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""2cc93e20-58a2-4425-9810-9631c1e337bb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5a1e9435-d12b-4de6-af4a-878681b5de61"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack.Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f6be1103-9d36-451d-910f-6eaf1666462f"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Block"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""abe41327-2703-4b54-8d24-4120f15d8a43"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""b308528f-e82d-4162-94a2-bc4f6e24d312"",
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
                    ""id"": ""cac75e44-cf0a-4da9-ac99-a601eadb0fe7"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f4f23d33-2738-436f-a8d3-ebebb694abc5"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""14f4561d-1b5c-4109-b8d3-862a9d97948e"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""13b6bef6-6fea-45d9-9752-7097fcf51e29"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""22166e87-f012-416b-83ee-7efbdb5c323a"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""92fcf87f-3f77-4d4a-835a-3e4db41609e6"",
            ""actions"": [
                {
                    ""name"": ""MenuMove"",
                    ""type"": ""Button"",
                    ""id"": ""4aa19a38-5aaf-4c45-a9c1-e1e3040bb6f3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveToBag"",
                    ""type"": ""Button"",
                    ""id"": ""83050b09-d837-483c-80d2-cf7647979034"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveToDeck"",
                    ""type"": ""Button"",
                    ""id"": ""9ff8d4e0-d6e7-4e4f-8515-fc4c469d8ea2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwitchMenu"",
                    ""type"": ""Button"",
                    ""id"": ""3cfd367b-6852-496f-be45-695783ac78e3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""3d72941f-df24-4c03-a62d-4899477cbc3c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MenuMove"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""454e9cf3-9e60-4491-a51f-89193944d6b2"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MenuMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""fbe5a66c-b235-448c-955a-0cd70c1bf035"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MenuMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e0224747-09ce-4ddf-be72-3001975b79d7"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MenuMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""56e9a668-2b5c-4303-8cf4-a8ec6e2b8b73"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MenuMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7ac49964-e72a-443d-84df-ad72bbf1b84f"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveToBag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5ab44c89-58ee-4d13-986c-c170288b8aee"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveToDeck"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cd13a3f2-e9de-4927-896a-d5908f536254"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Camera"",
            ""id"": ""b9c2a79f-f4e3-488c-ac8c-ba18a0756435"",
            ""actions"": [
                {
                    ""name"": ""Camera"",
                    ""type"": ""Button"",
                    ""id"": ""08cc0ea6-8372-4d8a-8c4f-51b386fcee15"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""42c7fa1b-9e3f-4d98-a0f9-479be93bae00"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""73dc35fc-8e54-442b-8f14-cc0af6a71577"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""bb507ef9-253b-4c77-a37c-c95dc33ff6ce"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e15f37c4-0261-4e0b-8c1e-58bdf31555a9"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a3e9b9c8-3565-491b-a8be-6048cf3bd2f0"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Hand
        m_Hand = asset.FindActionMap("Hand", throwIfNotFound: true);
        m_Hand_Shift = m_Hand.FindAction("Shift", throwIfNotFound: true);
        m_Hand_PlayCard = m_Hand.FindAction("PlayCard", throwIfNotFound: true);
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_AttackInteract = m_Player.FindAction("Attack.Interact", throwIfNotFound: true);
        m_Player_Block = m_Player.FindAction("Block", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Pause = m_Player.FindAction("Pause", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_MenuMove = m_UI.FindAction("MenuMove", throwIfNotFound: true);
        m_UI_MoveToBag = m_UI.FindAction("MoveToBag", throwIfNotFound: true);
        m_UI_MoveToDeck = m_UI.FindAction("MoveToDeck", throwIfNotFound: true);
        m_UI_SwitchMenu = m_UI.FindAction("SwitchMenu", throwIfNotFound: true);
        // Camera
        m_Camera = asset.FindActionMap("Camera", throwIfNotFound: true);
        m_Camera_Camera = m_Camera.FindAction("Camera", throwIfNotFound: true);
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

    // Hand
    private readonly InputActionMap m_Hand;
    private IHandActions m_HandActionsCallbackInterface;
    private readonly InputAction m_Hand_Shift;
    private readonly InputAction m_Hand_PlayCard;
    public struct HandActions
    {
        private @PlayerControls m_Wrapper;
        public HandActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shift => m_Wrapper.m_Hand_Shift;
        public InputAction @PlayCard => m_Wrapper.m_Hand_PlayCard;
        public InputActionMap Get() { return m_Wrapper.m_Hand; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(HandActions set) { return set.Get(); }
        public void SetCallbacks(IHandActions instance)
        {
            if (m_Wrapper.m_HandActionsCallbackInterface != null)
            {
                @Shift.started -= m_Wrapper.m_HandActionsCallbackInterface.OnShift;
                @Shift.performed -= m_Wrapper.m_HandActionsCallbackInterface.OnShift;
                @Shift.canceled -= m_Wrapper.m_HandActionsCallbackInterface.OnShift;
                @PlayCard.started -= m_Wrapper.m_HandActionsCallbackInterface.OnPlayCard;
                @PlayCard.performed -= m_Wrapper.m_HandActionsCallbackInterface.OnPlayCard;
                @PlayCard.canceled -= m_Wrapper.m_HandActionsCallbackInterface.OnPlayCard;
            }
            m_Wrapper.m_HandActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Shift.started += instance.OnShift;
                @Shift.performed += instance.OnShift;
                @Shift.canceled += instance.OnShift;
                @PlayCard.started += instance.OnPlayCard;
                @PlayCard.performed += instance.OnPlayCard;
                @PlayCard.canceled += instance.OnPlayCard;
            }
        }
    }
    public HandActions @Hand => new HandActions(this);

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_AttackInteract;
    private readonly InputAction m_Player_Block;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Pause;
    public struct PlayerActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @AttackInteract => m_Wrapper.m_Player_AttackInteract;
        public InputAction @Block => m_Wrapper.m_Player_Block;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Pause => m_Wrapper.m_Player_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @AttackInteract.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttackInteract;
                @AttackInteract.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttackInteract;
                @AttackInteract.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttackInteract;
                @Block.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBlock;
                @Block.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBlock;
                @Block.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBlock;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Pause.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @AttackInteract.started += instance.OnAttackInteract;
                @AttackInteract.performed += instance.OnAttackInteract;
                @AttackInteract.canceled += instance.OnAttackInteract;
                @Block.started += instance.OnBlock;
                @Block.performed += instance.OnBlock;
                @Block.canceled += instance.OnBlock;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_MenuMove;
    private readonly InputAction m_UI_MoveToBag;
    private readonly InputAction m_UI_MoveToDeck;
    private readonly InputAction m_UI_SwitchMenu;
    public struct UIActions
    {
        private @PlayerControls m_Wrapper;
        public UIActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MenuMove => m_Wrapper.m_UI_MenuMove;
        public InputAction @MoveToBag => m_Wrapper.m_UI_MoveToBag;
        public InputAction @MoveToDeck => m_Wrapper.m_UI_MoveToDeck;
        public InputAction @SwitchMenu => m_Wrapper.m_UI_SwitchMenu;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @MenuMove.started -= m_Wrapper.m_UIActionsCallbackInterface.OnMenuMove;
                @MenuMove.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnMenuMove;
                @MenuMove.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnMenuMove;
                @MoveToBag.started -= m_Wrapper.m_UIActionsCallbackInterface.OnMoveToBag;
                @MoveToBag.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnMoveToBag;
                @MoveToBag.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnMoveToBag;
                @MoveToDeck.started -= m_Wrapper.m_UIActionsCallbackInterface.OnMoveToDeck;
                @MoveToDeck.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnMoveToDeck;
                @MoveToDeck.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnMoveToDeck;
                @SwitchMenu.started -= m_Wrapper.m_UIActionsCallbackInterface.OnSwitchMenu;
                @SwitchMenu.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnSwitchMenu;
                @SwitchMenu.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnSwitchMenu;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MenuMove.started += instance.OnMenuMove;
                @MenuMove.performed += instance.OnMenuMove;
                @MenuMove.canceled += instance.OnMenuMove;
                @MoveToBag.started += instance.OnMoveToBag;
                @MoveToBag.performed += instance.OnMoveToBag;
                @MoveToBag.canceled += instance.OnMoveToBag;
                @MoveToDeck.started += instance.OnMoveToDeck;
                @MoveToDeck.performed += instance.OnMoveToDeck;
                @MoveToDeck.canceled += instance.OnMoveToDeck;
                @SwitchMenu.started += instance.OnSwitchMenu;
                @SwitchMenu.performed += instance.OnSwitchMenu;
                @SwitchMenu.canceled += instance.OnSwitchMenu;
            }
        }
    }
    public UIActions @UI => new UIActions(this);

    // Camera
    private readonly InputActionMap m_Camera;
    private ICameraActions m_CameraActionsCallbackInterface;
    private readonly InputAction m_Camera_Camera;
    public struct CameraActions
    {
        private @PlayerControls m_Wrapper;
        public CameraActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Camera => m_Wrapper.m_Camera_Camera;
        public InputActionMap Get() { return m_Wrapper.m_Camera; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CameraActions set) { return set.Get(); }
        public void SetCallbacks(ICameraActions instance)
        {
            if (m_Wrapper.m_CameraActionsCallbackInterface != null)
            {
                @Camera.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnCamera;
                @Camera.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnCamera;
                @Camera.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnCamera;
            }
            m_Wrapper.m_CameraActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Camera.started += instance.OnCamera;
                @Camera.performed += instance.OnCamera;
                @Camera.canceled += instance.OnCamera;
            }
        }
    }
    public CameraActions @Camera => new CameraActions(this);
    public interface IHandActions
    {
        void OnShift(InputAction.CallbackContext context);
        void OnPlayCard(InputAction.CallbackContext context);
    }
    public interface IPlayerActions
    {
        void OnAttackInteract(InputAction.CallbackContext context);
        void OnBlock(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnMenuMove(InputAction.CallbackContext context);
        void OnMoveToBag(InputAction.CallbackContext context);
        void OnMoveToDeck(InputAction.CallbackContext context);
        void OnSwitchMenu(InputAction.CallbackContext context);
    }
    public interface ICameraActions
    {
        void OnCamera(InputAction.CallbackContext context);
    }
}
