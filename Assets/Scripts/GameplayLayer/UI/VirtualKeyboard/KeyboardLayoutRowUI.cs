using System;
using System.Collections.Generic;
using UnityEngine;

namespace Hangman.GameplayLayer {
    public class KeyboardLayoutRowUI : MonoBehaviour {

        [SerializeField] private GameObject keyPrefab = null;

        private List<KeyboardLayoutKeyUI> keyUIList = null;

        public event Action<char> KeyPressed = null;

        private void OnEnable() {
            RegisterListeners();
        }

        private void OnDisable() {
            UnregisterListeners();
        }

        public void Initialize(KeyboardLayoutRow row) {
            Debug.Assert(keyUIList == null, "Trying to initialize a non-null Key UI");

            keyUIList = new List<KeyboardLayoutKeyUI>(row.CharacterList.Length);
            foreach (var key in row.CharacterList) {
                GameObject keyGO = Instantiate(keyPrefab, this.transform);
                var keyUI = keyGO.GetComponent<KeyboardLayoutKeyUI>();

                Debug.Assert(keyUI != null, "Keyboard Row UI Template Prefab does not seem to have the Keyboard Layout Row UI Component");

                keyUI.SetKey(key);
                keyUIList.Add(keyUI);
            }

            RegisterListeners();
        }

        internal void Reset() {
            if (keyUIList == null) return;

            foreach (KeyboardLayoutKeyUI keyUI in keyUIList) {
                keyUI.ToggleKey(true);
            }
        }

        internal void DisableKey(char key) {
            if (keyUIList == null) return;

            foreach (KeyboardLayoutKeyUI keyUI in keyUIList) {
                if (keyUI.KeyCode == key)
                {
                    keyUI.ToggleKey(false);
                }
            }
        }

        private void RegisterListeners() {
            if (keyUIList == null) return;

            foreach (KeyboardLayoutKeyUI keyUI in keyUIList) {
                keyUI.KeyPressed += OnKeyPressed;
            }
        }

        private void UnregisterListeners() {
            if (keyUIList == null) return;

            foreach (KeyboardLayoutKeyUI keyUI in keyUIList) {
                keyUI.KeyPressed -= OnKeyPressed;
            }
        }

        private void OnKeyPressed(char key) {
            KeyPressed?.Invoke(key);
        }
    }
}