using Sirenix.OdinInspector;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Hangman.GameplayLayer {
    public class EndGamePopupUI : MonoBehaviour
    {
        [SerializeField][Required] Button proceedButton = null;
        [SerializeField][Required] private AudioSource eventAudio = null;

        public event Action RestartButtonClicked = null;

        private void OnEnable() {
            proceedButton.onClick.AddListener(OnRestartButtonClicked);
            eventAudio.Play();
        }

        private void OnDisable() {
            proceedButton.onClick.RemoveListener(OnRestartButtonClicked);
        }

        private void OnRestartButtonClicked() {
            RestartButtonClicked?.Invoke();
        }

        public void Activate() {
            gameObject.SetActive(true);
        }

        public void Deactivate() {
            gameObject.SetActive(false);
        }
    }
}
