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
        }
    ],
    ""controlSchemes"": []
}");
        // Hand
        m_Hand = asset.FindActionMap("Hand", throwIfNotFound: true);
        m_Hand_Shift = m_Hand.FindAction("Shift", throwIfNotFound: true);
        m_Hand_PlayCard = m_Hand.FindAction("PlayCard", throwIfNotFound: true);
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
    public interface IHandActions
    {
        void OnShift(InputAction.CallbackContext context);
        void OnPlayCard(InputAction.CallbackContext context);
    }
}
