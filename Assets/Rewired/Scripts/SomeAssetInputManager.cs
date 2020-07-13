// Copyright (c) 2017 Augie R. Maddox, Guavaman Enterprises. All rights reserved.

#pragma warning disable 0649

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Rewired.Integration.SomeAsset {

    [RequireComponent(typeof(Rewired.InputManager))]
    public sealed class SomeAssetInputManager : global::InputManager {

        private const string className = "Rewired Some Asset Input Manager";

		[Header("Action Mappings")]
		[Tooltip("The string name of the Rewired Action to use for the game PickUp action.")]
		[SerializeField]
		private string _pickupAction;
		[Tooltip("The string name of the Rewired Action to use for the game Jump action.")]
		[SerializeField]
		private string _jumpAction;
		[SerializeField]
		[Tooltip("The string name of the Rewired Action to use for the game Throw action.")]
		private string _throwAction;
		[SerializeField]
		[Tooltip("The string name of the Rewired Action to use for the game Horizontal action.")]
		private string _horizontalAction;
		[SerializeField]
		[Tooltip("The string name of the Rewired Action to use for the game Vertical action.")]
		private string _verticalAction;

        private Dictionary<int, int> _actionIds;
        private bool _initialized;

        protected override void Awake() {
            base.Awake();

            if(!ReInput.isReady) {
                Debug.LogError(className + ": Rewired is not initialized. You must have an active Rewired Input Manager in the scene.");
                return;
            }

            _initialized = true;

            // Cache Rewired Action ids for speed
            _actionIds = new Dictionary<int, int>();
            AddRewiredActionId(_actionIds, _pickupAction, global::InputAction.Interact);
            AddRewiredActionId(_actionIds, _pickupAction, global::InputAction.Jump);
            AddRewiredActionId(_actionIds, _throwAction, global::InputAction.Throw);
            AddRewiredActionId(_actionIds, _horizontalAction, global::InputAction.MoveHorizontal);
            AddRewiredActionId(_actionIds, _verticalAction, global::InputAction.MoveVertical);

            // Set the singleton instance
            SetInstance(this);
        }

        protected override void OnEnable() {
            base.OnEnable();
            ReInput.ControllerConnectedEvent += OnControllerConnected;
            ReInput.ControllerDisconnectedEvent += OnControllerDisconnected;
        }

        protected override void OnDisable() {
            base.OnDisable();
            ReInput.ControllerConnectedEvent -= OnControllerConnected;
            ReInput.ControllerDisconnectedEvent -= OnControllerDisconnected;
        }

        // Public methods

        public override bool GetButton(int playerId, global::InputAction action) {
            if(!_initialized || !isEnabled) return false;
            return ReInput.players.GetPlayer(playerId).GetButton(_actionIds[(int)action]);
        }

        public override bool GetButtonDown(int playerId, global::InputAction action) {
            if(!_initialized || !isEnabled) return false;
            return ReInput.players.GetPlayer(playerId).GetButtonDown(_actionIds[(int)action]);
        }

        public override bool GetButtonUp(int playerId, global::InputAction action) {
            if(!_initialized || !isEnabled) return false;
            return ReInput.players.GetPlayer(playerId).GetButtonUp(_actionIds[(int)action]);
        }

        public override float GetAxis(int playerId, global::InputAction action) {
            if(!_initialized || !isEnabled) return 0f;
            return ReInput.players.GetPlayer(playerId).GetAxis(_actionIds[(int)action]);
        }

        public override float GetAxisRaw(int playerId, global::InputAction action)
        {
            if (!_initialized || !isEnabled) return 0f;
            return ReInput.players.GetPlayer(playerId).GetAxisRaw(_actionIds[(int)action]);
        }

        // Private methods

        private void OnControllerConnected(Rewired.ControllerStatusChangedEventArgs args) {
            if(args.controllerType != ControllerType.Joystick) return;
        }

        private void OnControllerDisconnected(Rewired.ControllerStatusChangedEventArgs args) {
            if(args.controllerType != ControllerType.Joystick) return;
        }

        private static void AddRewiredActionId(Dictionary<int, int> actionIds, string actionName, global::InputAction action) {
            int id = GetRewiredActionId(actionName);
            if(id < 0) return; // invalid Action id
            actionIds.Add((int)action, id);
        }

        private static int GetRewiredActionId(string actionName) {
            if(string.IsNullOrEmpty(actionName)) return -1;
            int id = ReInput.mapping.GetActionId(actionName);
            if(id < 0) Debug.LogWarning(className + ": No Rewired Action found for Action name \"" + actionName + "\". The Action name must match exactly to an Action defined in the Rewired Input Manager.");
            return id;
        }

        private enum PlatformFlags {
            None = 0,
            Editor = 1,
            Windows = 1 << 1,
            OSX = 1 << 2,
            Linux = 1 << 3,
            IOS = 1 << 4,
            TVOS = 1 << 5,
            Android = 1 << 6,
            Windows8Store = 1 << 7,
            WindowsUWP10 = 1 << 8,
            WebGL = 1 << 9,
            PS4 = 1 << 10,
            PSVita = 1 << 11,
            Xbox360 = 1 << 12,
            XboxOne = 1 << 13,
            SamsungTV = 1 << 14,
            WiiU = 1 << 15,
            Nintendo3DS = 1 << 16,
            Switch = 1 << 17,
            AmazonFireTV = 1 << 18,
            RazerForgeTV = 1 << 19,
            Unknown = 1 << 31
        }
    }
}