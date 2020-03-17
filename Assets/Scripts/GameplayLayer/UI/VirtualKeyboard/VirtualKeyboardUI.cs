using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Hangman.GameplayLayer {

    public class VirtualKeyboardUI : MonoBehaviour
    {
        [SerializeField] [Required] private VirtualKeyboardLayout layout = null;
        [SerializeField] [Required] private GameObject keyboardRowPrefab = null;

        private List<KeyboardLayoutRowUI> rowUIList = null;

        public event Action<char> KeyPressed = null;

        private void Start() {
            Initialize();
        }

        private void OnEnable() {
            UnregisterListeners();
        }

        private void OnDisable() {
            RegisterListeners();
        }

        internal void Reset() {
            if (rowUIList == null) return;

            foreach (var row in rowUIList) {
                row.Reset();
            }
        }

        private void Initialize() {
            rowUIList = new List<KeyboardLayoutRowUI>(layout.RowList.Count);
            foreach (KeyboardLayoutRow row in layout.RowList) {
                GameObject rowGO = Instantiate(keyboardRowPrefab, this.transform);
                var rowUI = rowGO.GetComponent<KeyboardLayoutRowUI>();

                Debug.Assert(rowUI != null, "Keyboard Row UI Template Prefab does not seem to have the Keyboard Layout Row UI Component");

                rowUI.Initialize(row);
                rowUIList.Add(rowUI);
            }
            RegisterListeners();
        }

        internal void DisableKey(char key) {
            if (rowUIList == null) return;

            foreach (var row in rowUIList) {
                row.DisableKey(key);
            }
        }

        private void RegisterListeners() {
            if (rowUIList == null) return;

            foreach (var row in rowUIList) {
                row.KeyPressed += OnKeyPressed;
            }
        }

        private void UnregisterListeners() {
            if (rowUIList == null) return;

            foreach (var row in rowUIList) {
                row.KeyPressed -= OnKeyPressed;
            }
        }

        private void OnKeyPressed(char key) {
            KeyPressed?.Invoke(key);
        }
    }
}