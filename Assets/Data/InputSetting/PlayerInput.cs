//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.2
//     from Assets/Data/InputSetting/PlayerInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""LocalPlayer"",
            ""id"": ""eade0b78-2ece-444a-9186-c739fc7dc68c"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""b2a7dd76-a579-499e-b3c1-9a2099112f17"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""fd686667-7175-456c-991c-80188733c96a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""be159af1-b8bd-4b80-b272-f3ea51d4e858"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""57d18b5e-f94d-4c04-a157-089786e0f5dd"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""224f2f18-edcb-4ac1-a01c-5f7cdffc8612"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""36f0a2f2-1cb2-466c-b733-2b0338626aee"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow"",
                    ""id"": ""8c31e206-73b7-4205-afb2-cc278c5617bc"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8f741a33-19d1-4360-a660-ffd131e811a5"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""fd8a2fe0-cd2c-4563-aa63-2fa3b66fed25"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""98360055-7390-43cf-9d71-2999c1b8074f"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a1041d41-cfa1-4cc9-b302-466819b96c24"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""GlobalInput"",
            ""id"": ""79e5acaa-6504-494b-8c4f-c5f9d0760b93"",
            ""actions"": [
                {
                    ""name"": ""Click"",
                    ""type"": ""Value"",
                    ""id"": ""347405c3-862f-4275-bd94-7ef24008c569"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Hold"",
                    ""type"": ""Button"",
                    ""id"": ""546f0509-b692-49ca-b5ea-9687c510fe94"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Additional"",
                    ""type"": ""Button"",
                    ""id"": ""68bdbb79-3b53-4cf0-b4bf-7a139ef7ec6a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d9915b61-47da-4caf-9cfb-9ff905ae2b0f"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3e51be93-836b-484b-bed5-2bb7e6c5e3fb"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Hold(duration=0.4,pressPoint=0.5)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Hold"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8cd5a1b3-cbf6-461a-bbb2-8ddc5e49ae47"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Additional"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // LocalPlayer
        m_LocalPlayer = asset.FindActionMap("LocalPlayer", throwIfNotFound: true);
        m_LocalPlayer_Move = m_LocalPlayer.FindAction("Move", throwIfNotFound: true);
        // GlobalInput
        m_GlobalInput = asset.FindActionMap("GlobalInput", throwIfNotFound: true);
        m_GlobalInput_Click = m_GlobalInput.FindAction("Click", throwIfNotFound: true);
        m_GlobalInput_Hold = m_GlobalInput.FindAction("Hold", throwIfNotFound: true);
        m_GlobalInput_Additional = m_GlobalInput.FindAction("Additional", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // LocalPlayer
    private readonly InputActionMap m_LocalPlayer;
    private ILocalPlayerActions m_LocalPlayerActionsCallbackInterface;
    private readonly InputAction m_LocalPlayer_Move;
    public struct LocalPlayerActions
    {
        private @PlayerInput m_Wrapper;
        public LocalPlayerActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_LocalPlayer_Move;
        public InputActionMap Get() { return m_Wrapper.m_LocalPlayer; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(LocalPlayerActions set) { return set.Get(); }
        public void SetCallbacks(ILocalPlayerActions instance)
        {
            if (m_Wrapper.m_LocalPlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_LocalPlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_LocalPlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_LocalPlayerActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_LocalPlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public LocalPlayerActions @LocalPlayer => new LocalPlayerActions(this);

    // GlobalInput
    private readonly InputActionMap m_GlobalInput;
    private IGlobalInputActions m_GlobalInputActionsCallbackInterface;
    private readonly InputAction m_GlobalInput_Click;
    private readonly InputAction m_GlobalInput_Hold;
    private readonly InputAction m_GlobalInput_Additional;
    public struct GlobalInputActions
    {
        private @PlayerInput m_Wrapper;
        public GlobalInputActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Click => m_Wrapper.m_GlobalInput_Click;
        public InputAction @Hold => m_Wrapper.m_GlobalInput_Hold;
        public InputAction @Additional => m_Wrapper.m_GlobalInput_Additional;
        public InputActionMap Get() { return m_Wrapper.m_GlobalInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GlobalInputActions set) { return set.Get(); }
        public void SetCallbacks(IGlobalInputActions instance)
        {
            if (m_Wrapper.m_GlobalInputActionsCallbackInterface != null)
            {
                @Click.started -= m_Wrapper.m_GlobalInputActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_GlobalInputActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_GlobalInputActionsCallbackInterface.OnClick;
                @Hold.started -= m_Wrapper.m_GlobalInputActionsCallbackInterface.OnHold;
                @Hold.performed -= m_Wrapper.m_GlobalInputActionsCallbackInterface.OnHold;
                @Hold.canceled -= m_Wrapper.m_GlobalInputActionsCallbackInterface.OnHold;
                @Additional.started -= m_Wrapper.m_GlobalInputActionsCallbackInterface.OnAdditional;
                @Additional.performed -= m_Wrapper.m_GlobalInputActionsCallbackInterface.OnAdditional;
                @Additional.canceled -= m_Wrapper.m_GlobalInputActionsCallbackInterface.OnAdditional;
            }
            m_Wrapper.m_GlobalInputActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
                @Hold.started += instance.OnHold;
                @Hold.performed += instance.OnHold;
                @Hold.canceled += instance.OnHold;
                @Additional.started += instance.OnAdditional;
                @Additional.performed += instance.OnAdditional;
                @Additional.canceled += instance.OnAdditional;
            }
        }
    }
    public GlobalInputActions @GlobalInput => new GlobalInputActions(this);
    public interface ILocalPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
    }
    public interface IGlobalInputActions
    {
        void OnClick(InputAction.CallbackContext context);
        void OnHold(InputAction.CallbackContext context);
        void OnAdditional(InputAction.CallbackContext context);
    }
}
