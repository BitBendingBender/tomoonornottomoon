//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/InputSettings/InputActions.inputactions
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

namespace TheMoon
{
    public partial class @InputActions : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @InputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""ingame"",
            ""id"": ""5e19e7d4-b950-45a1-952f-dd82a932ebdd"",
            ""actions"": [
                {
                    ""name"": ""mooning"",
                    ""type"": ""Value"",
                    ""id"": ""c303e1ff-f676-4dce-9c04-353dee8758f8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ff49f0da-b3f2-44bc-bcdc-86fd3a5e01c9"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""mooning"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""menu"",
            ""id"": ""707a3d55-9408-472b-b306-0e685509a4f3"",
            ""actions"": [
                {
                    ""name"": ""startgame"",
                    ""type"": ""Value"",
                    ""id"": ""ecffb906-a466-4a60-bc4c-aeb08448fbfa"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""79438350-51ab-4ef5-a773-a63af29e2d5f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""startgame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""gameover"",
            ""id"": ""bc5d8d30-eea2-4212-ab11-695db9d68e78"",
            ""actions"": [
                {
                    ""name"": ""startgame"",
                    ""type"": ""Value"",
                    ""id"": ""af61e511-5655-450f-8689-bc4bd4825fa2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""09f438b1-acc2-4d68-b419-9a840a824652"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""startgame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // ingame
            m_ingame = asset.FindActionMap("ingame", throwIfNotFound: true);
            m_ingame_mooning = m_ingame.FindAction("mooning", throwIfNotFound: true);
            // menu
            m_menu = asset.FindActionMap("menu", throwIfNotFound: true);
            m_menu_startgame = m_menu.FindAction("startgame", throwIfNotFound: true);
            // gameover
            m_gameover = asset.FindActionMap("gameover", throwIfNotFound: true);
            m_gameover_startgame = m_gameover.FindAction("startgame", throwIfNotFound: true);
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

        // ingame
        private readonly InputActionMap m_ingame;
        private IIngameActions m_IngameActionsCallbackInterface;
        private readonly InputAction m_ingame_mooning;
        public struct IngameActions
        {
            private @InputActions m_Wrapper;
            public IngameActions(@InputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @mooning => m_Wrapper.m_ingame_mooning;
            public InputActionMap Get() { return m_Wrapper.m_ingame; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(IngameActions set) { return set.Get(); }
            public void SetCallbacks(IIngameActions instance)
            {
                if (m_Wrapper.m_IngameActionsCallbackInterface != null)
                {
                    @mooning.started -= m_Wrapper.m_IngameActionsCallbackInterface.OnMooning;
                    @mooning.performed -= m_Wrapper.m_IngameActionsCallbackInterface.OnMooning;
                    @mooning.canceled -= m_Wrapper.m_IngameActionsCallbackInterface.OnMooning;
                }
                m_Wrapper.m_IngameActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @mooning.started += instance.OnMooning;
                    @mooning.performed += instance.OnMooning;
                    @mooning.canceled += instance.OnMooning;
                }
            }
        }
        public IngameActions @ingame => new IngameActions(this);

        // menu
        private readonly InputActionMap m_menu;
        private IMenuActions m_MenuActionsCallbackInterface;
        private readonly InputAction m_menu_startgame;
        public struct MenuActions
        {
            private @InputActions m_Wrapper;
            public MenuActions(@InputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @startgame => m_Wrapper.m_menu_startgame;
            public InputActionMap Get() { return m_Wrapper.m_menu; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
            public void SetCallbacks(IMenuActions instance)
            {
                if (m_Wrapper.m_MenuActionsCallbackInterface != null)
                {
                    @startgame.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnStartgame;
                    @startgame.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnStartgame;
                    @startgame.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnStartgame;
                }
                m_Wrapper.m_MenuActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @startgame.started += instance.OnStartgame;
                    @startgame.performed += instance.OnStartgame;
                    @startgame.canceled += instance.OnStartgame;
                }
            }
        }
        public MenuActions @menu => new MenuActions(this);

        // gameover
        private readonly InputActionMap m_gameover;
        private IGameoverActions m_GameoverActionsCallbackInterface;
        private readonly InputAction m_gameover_startgame;
        public struct GameoverActions
        {
            private @InputActions m_Wrapper;
            public GameoverActions(@InputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @startgame => m_Wrapper.m_gameover_startgame;
            public InputActionMap Get() { return m_Wrapper.m_gameover; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GameoverActions set) { return set.Get(); }
            public void SetCallbacks(IGameoverActions instance)
            {
                if (m_Wrapper.m_GameoverActionsCallbackInterface != null)
                {
                    @startgame.started -= m_Wrapper.m_GameoverActionsCallbackInterface.OnStartgame;
                    @startgame.performed -= m_Wrapper.m_GameoverActionsCallbackInterface.OnStartgame;
                    @startgame.canceled -= m_Wrapper.m_GameoverActionsCallbackInterface.OnStartgame;
                }
                m_Wrapper.m_GameoverActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @startgame.started += instance.OnStartgame;
                    @startgame.performed += instance.OnStartgame;
                    @startgame.canceled += instance.OnStartgame;
                }
            }
        }
        public GameoverActions @gameover => new GameoverActions(this);
        public interface IIngameActions
        {
            void OnMooning(InputAction.CallbackContext context);
        }
        public interface IMenuActions
        {
            void OnStartgame(InputAction.CallbackContext context);
        }
        public interface IGameoverActions
        {
            void OnStartgame(InputAction.CallbackContext context);
        }
    }
}
