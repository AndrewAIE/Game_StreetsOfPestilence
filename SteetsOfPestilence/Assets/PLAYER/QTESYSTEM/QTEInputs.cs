//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/PLAYER/QTESYSTEM/QTEInputs.inputactions
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

namespace QTESystem
{
    public partial class @QTEInputs: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @QTEInputs()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""QTEInputs"",
    ""maps"": [
        {
            ""name"": ""Inputs"",
            ""id"": ""5377b83e-1a56-4e62-b08e-646a1a77717d"",
            ""actions"": [
                {
                    ""name"": ""North"",
                    ""type"": ""Button"",
                    ""id"": ""d1ed0c70-eb9d-4cd8-a399-d5429041643d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""East"",
                    ""type"": ""Button"",
                    ""id"": ""d7057732-c5ac-43be-99f3-2157223d4ef5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""South"",
                    ""type"": ""Button"",
                    ""id"": ""e7ba8d51-3e47-4db0-b79d-9d8847900ab6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""West"",
                    ""type"": ""Button"",
                    ""id"": ""5a5b072f-837d-4c42-81f5-92f94d5c40a7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RShoulder"",
                    ""type"": ""Button"",
                    ""id"": ""085d0e0a-e921-413d-a983-3c671e76699c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LShoulder"",
                    ""type"": ""Button"",
                    ""id"": ""3abc9f56-9fd1-48d9-993b-622ef86696e0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RTrigger"",
                    ""type"": ""Button"",
                    ""id"": ""23e1e462-7818-4d8c-a86d-766e7085e044"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LTrigger"",
                    ""type"": ""Button"",
                    ""id"": ""73dba553-f488-4b63-9698-eb1b0d9157df"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Win"",
                    ""type"": ""Button"",
                    ""id"": ""006c37c4-c578-4a7e-96ce-f1307d1f35e8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""09392281-0458-4b77-8c08-ac47a3096afe"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""North"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ff72c5c0-5e94-4329-9bdf-260f26e76029"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""North"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""683cd450-d937-42b1-894d-4cc00213256c"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""East"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4170ec7c-1d4e-434e-8905-c5b47709ea3d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""East"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e5027396-33d9-4f3d-8662-800346073c0f"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""South"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""64004a21-8184-4bc2-ab96-680d7620117b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""South"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7aa3fbc7-47d0-416d-beac-7972ee89d53e"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""West"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f6445513-61bc-46b0-a39e-ddfab6d87c72"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""West"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0ce98986-000b-4af9-b5f1-732aebadcb45"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RShoulder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""343139c8-1d38-446d-a462-e3d2745d0482"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RShoulder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""612d87f1-519e-4e28-94c3-15fc71f04e16"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LShoulder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c79cfdf6-630a-4b5d-8d98-a3da35c988a3"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LShoulder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""245b96a0-be96-4d29-a3d0-65f879f905c9"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RTrigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""385e0aeb-a950-4b84-b095-6691293651cf"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RTrigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cba37c7e-dbc3-447c-985b-c8b86fdaa4b1"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LTrigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ba141ed1-e719-49bb-a744-42d075b38408"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LTrigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a6416960-dba6-4eee-8700-87edc7d57962"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Win"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Inputs
            m_Inputs = asset.FindActionMap("Inputs", throwIfNotFound: true);
            m_Inputs_North = m_Inputs.FindAction("North", throwIfNotFound: true);
            m_Inputs_East = m_Inputs.FindAction("East", throwIfNotFound: true);
            m_Inputs_South = m_Inputs.FindAction("South", throwIfNotFound: true);
            m_Inputs_West = m_Inputs.FindAction("West", throwIfNotFound: true);
            m_Inputs_RShoulder = m_Inputs.FindAction("RShoulder", throwIfNotFound: true);
            m_Inputs_LShoulder = m_Inputs.FindAction("LShoulder", throwIfNotFound: true);
            m_Inputs_RTrigger = m_Inputs.FindAction("RTrigger", throwIfNotFound: true);
            m_Inputs_LTrigger = m_Inputs.FindAction("LTrigger", throwIfNotFound: true);
            m_Inputs_Win = m_Inputs.FindAction("Win", throwIfNotFound: true);
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

        // Inputs
        private readonly InputActionMap m_Inputs;
        private List<IInputsActions> m_InputsActionsCallbackInterfaces = new List<IInputsActions>();
        private readonly InputAction m_Inputs_North;
        private readonly InputAction m_Inputs_East;
        private readonly InputAction m_Inputs_South;
        private readonly InputAction m_Inputs_West;
        private readonly InputAction m_Inputs_RShoulder;
        private readonly InputAction m_Inputs_LShoulder;
        private readonly InputAction m_Inputs_RTrigger;
        private readonly InputAction m_Inputs_LTrigger;
        private readonly InputAction m_Inputs_Win;
        public struct InputsActions
        {
            private @QTEInputs m_Wrapper;
            public InputsActions(@QTEInputs wrapper) { m_Wrapper = wrapper; }
            public InputAction @North => m_Wrapper.m_Inputs_North;
            public InputAction @East => m_Wrapper.m_Inputs_East;
            public InputAction @South => m_Wrapper.m_Inputs_South;
            public InputAction @West => m_Wrapper.m_Inputs_West;
            public InputAction @RShoulder => m_Wrapper.m_Inputs_RShoulder;
            public InputAction @LShoulder => m_Wrapper.m_Inputs_LShoulder;
            public InputAction @RTrigger => m_Wrapper.m_Inputs_RTrigger;
            public InputAction @LTrigger => m_Wrapper.m_Inputs_LTrigger;
            public InputAction @Win => m_Wrapper.m_Inputs_Win;
            public InputActionMap Get() { return m_Wrapper.m_Inputs; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(InputsActions set) { return set.Get(); }
            public void AddCallbacks(IInputsActions instance)
            {
                if (instance == null || m_Wrapper.m_InputsActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_InputsActionsCallbackInterfaces.Add(instance);
                @North.started += instance.OnNorth;
                @North.performed += instance.OnNorth;
                @North.canceled += instance.OnNorth;
                @East.started += instance.OnEast;
                @East.performed += instance.OnEast;
                @East.canceled += instance.OnEast;
                @South.started += instance.OnSouth;
                @South.performed += instance.OnSouth;
                @South.canceled += instance.OnSouth;
                @West.started += instance.OnWest;
                @West.performed += instance.OnWest;
                @West.canceled += instance.OnWest;
                @RShoulder.started += instance.OnRShoulder;
                @RShoulder.performed += instance.OnRShoulder;
                @RShoulder.canceled += instance.OnRShoulder;
                @LShoulder.started += instance.OnLShoulder;
                @LShoulder.performed += instance.OnLShoulder;
                @LShoulder.canceled += instance.OnLShoulder;
                @RTrigger.started += instance.OnRTrigger;
                @RTrigger.performed += instance.OnRTrigger;
                @RTrigger.canceled += instance.OnRTrigger;
                @LTrigger.started += instance.OnLTrigger;
                @LTrigger.performed += instance.OnLTrigger;
                @LTrigger.canceled += instance.OnLTrigger;
                @Win.started += instance.OnWin;
                @Win.performed += instance.OnWin;
                @Win.canceled += instance.OnWin;
            }

            private void UnregisterCallbacks(IInputsActions instance)
            {
                @North.started -= instance.OnNorth;
                @North.performed -= instance.OnNorth;
                @North.canceled -= instance.OnNorth;
                @East.started -= instance.OnEast;
                @East.performed -= instance.OnEast;
                @East.canceled -= instance.OnEast;
                @South.started -= instance.OnSouth;
                @South.performed -= instance.OnSouth;
                @South.canceled -= instance.OnSouth;
                @West.started -= instance.OnWest;
                @West.performed -= instance.OnWest;
                @West.canceled -= instance.OnWest;
                @RShoulder.started -= instance.OnRShoulder;
                @RShoulder.performed -= instance.OnRShoulder;
                @RShoulder.canceled -= instance.OnRShoulder;
                @LShoulder.started -= instance.OnLShoulder;
                @LShoulder.performed -= instance.OnLShoulder;
                @LShoulder.canceled -= instance.OnLShoulder;
                @RTrigger.started -= instance.OnRTrigger;
                @RTrigger.performed -= instance.OnRTrigger;
                @RTrigger.canceled -= instance.OnRTrigger;
                @LTrigger.started -= instance.OnLTrigger;
                @LTrigger.performed -= instance.OnLTrigger;
                @LTrigger.canceled -= instance.OnLTrigger;
                @Win.started -= instance.OnWin;
                @Win.performed -= instance.OnWin;
                @Win.canceled -= instance.OnWin;
            }

            public void RemoveCallbacks(IInputsActions instance)
            {
                if (m_Wrapper.m_InputsActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IInputsActions instance)
            {
                foreach (var item in m_Wrapper.m_InputsActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_InputsActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public InputsActions @Inputs => new InputsActions(this);
        public interface IInputsActions
        {
            void OnNorth(InputAction.CallbackContext context);
            void OnEast(InputAction.CallbackContext context);
            void OnSouth(InputAction.CallbackContext context);
            void OnWest(InputAction.CallbackContext context);
            void OnRShoulder(InputAction.CallbackContext context);
            void OnLShoulder(InputAction.CallbackContext context);
            void OnRTrigger(InputAction.CallbackContext context);
            void OnLTrigger(InputAction.CallbackContext context);
            void OnWin(InputAction.CallbackContext context);
        }
    }
}
