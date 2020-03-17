using Sirenix.OdinInspector;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Hangman.GameplayLayer {
    public class KeyboardLayoutKeyUI : MonoBehaviour
    {
        [SerializeField][Required] private TextMeshProUGUI keyText = null;
        [SerializeField][Required] private Button button = null;
        [SerializeField][Required] private AudioSource clickAudioSource = null;

        [ReadOnly] private char keyCode = ' ';

        public char KeyCode => keyCode;

        public event Action<char> KeyPressed;

        private void OnEnable() {
            button.onClick.AddListener(OnKeyClicked);
        }

        private void OnDisable() {
            button.onClick.RemoveListener(OnKeyClicked);
        }

        public void SetKey(char value) {
            keyCode = value;
            keyText.text = "" + keyCode;
        }
    
        private void OnKeyClicked() {
            KeyPressed?.Invoke(keyCode);
            clickAudioSource.Play();
        }

        internal void ToggleKey(bool status) {
            button.interactable = status;
        }
    }
}
