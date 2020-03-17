using Sirenix.OdinInspector;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Hangman.GameplayLayer {

    public class RulesUI : MonoBehaviour {
        [SerializeField] [Required] private Button backButton = null;

        public event Action BackButtonPressed = null;

        private void OnEnable() {
            backButton?.onClick.AddListener(OnBackButtonPressed);
        }

        private void OnDisable() {
            backButton?.onClick.RemoveListener(OnBackButtonPressed);
        }

        private void OnBackButtonPressed() {
            BackButtonPressed?.Invoke();
        }

        public void Activate() {
            this.gameObject.SetActive(true);
        }

        public void Dectivate() {
            this.gameObject.SetActive(false);
        }
    }
}