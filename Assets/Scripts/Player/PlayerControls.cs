// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player/PlayerControls.inputactions'

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
            ""name"": ""Standard"",
            ""id"": ""1525ae45-021f-42cd-8e2d-afa81d9bca88"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""9b06ea7e-3ed5-4744-af87-b130e01c02c7"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c8067617-5acc-4b14-bf9e-b23e4467615a"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""9abd5f18-fc43-4873-a656-c70b4568a723"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""9c3ce6cf-cd33-4134-a551-2883f860e7ae"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b07e7f45-6c95-4717-ae72-9585c82bc654"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cbc0cbfa-ff26-40b1-9134-9097d5757525"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4854d7e0-8dde-4b5c-b15f-9d65a9e0cdf2"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""08f35b04-58df-41e0-a9a5-43ccc7ceaae0"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Standard
        m_Standard = asset.FindActionMap("Standard", throwIfNotFound: true);
        m_Standard_Move = m_Standard.FindAction("Move", throwIfNotFound: true);
        m_Standard_Look = m_Standard.FindAction("Look", throwIfNotFound: true);
        m_Standard_Shoot = m_Standard.FindAction("Shoot", throwIfNotFound: true);
        m_Standard_Reload = m_Standard.FindAction("Reload", throwIfNotFound: true);
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

    // Standard
    private readonly InputActionMap m_Standard;
    private IStandardActions m_StandardActionsCallbackInterface;
    private readonly InputAction m_Standard_Move;
    private readonly InputAction m_Standard_Look;
    private readonly InputAction m_Standard_Shoot;
    private readonly InputAction m_Standard_Reload;
    public struct StandardActions
    {
        private @PlayerControls m_Wrapper;
        public StandardActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Standard_Move;
        public InputAction @Look => m_Wrapper.m_Standard_Look;
        public InputAction @Shoot => m_Wrapper.m_Standard_Shoot;
        public InputAction @Reload => m_Wrapper.m_Standard_Reload;
        public InputActionMap Get() { return m_Wrapper.m_Standard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(StandardActions set) { return set.Get(); }
        public void SetCallbacks(IStandardActions instance)
        {
            if (m_Wrapper.m_StandardActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_StandardActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_StandardActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_StandardActionsCallbackInterface.OnMove;
                @Look.started -= m_Wrapper.m_StandardActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_StandardActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_StandardActionsCallbackInterface.OnLook;
                @Shoot.started -= m_Wrapper.m_StandardActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_StandardActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_StandardActionsCallbackInterface.OnShoot;
                @Reload.started -= m_Wrapper.m_StandardActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_StandardActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_StandardActionsCallbackInterface.OnReload;
            }
            m_Wrapper.m_StandardActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
            }
        }
    }
    public StandardActions @Standard => new StandardActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IStandardActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
    }
}
