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
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""5f27bfdc-edcc-4288-b7e7-55fa40acbc68"",
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
                    ""action"": ""New action"",
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
                    ""action"": ""New action"",
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
                    ""action"": ""New action"",
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
        m_Hand_Newaction = m_Hand.FindAction("New action", throwIfNotFound: true);
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
    private readonly InputAction m_Hand_Newaction;
    public struct HandActions
    {
        private @PlayerControls m_Wrapper;
        public HandActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_Hand_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_Hand; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(HandActions set) { return set.Get(); }
        public void SetCallbacks(IHandActions instance)
        {
            if (m_Wrapper.m_HandActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_HandActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_HandActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_HandActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_HandActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public HandActions @Hand => new HandActions(this);
    public interface IHandActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}
