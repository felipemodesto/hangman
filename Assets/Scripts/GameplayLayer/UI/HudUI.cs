using System;
using Hangman.BusinessLayer;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Hangman.GameplayLayer {
    public class HudUI : MonoBehaviour
    {
        [SerializeField][Required] private TextMeshProUGUI winCountText = null;
        [SerializeField][Required] private TextMeshProUGUI lossCountText = null;
        [SerializeField][Required] private TextMeshProUGUI winStreakCountText = null;
        [SerializeField][Required] private TextMeshProUGUI wrongAttemptsText = null;
        [SerializeField][Required] private TextMeshProUGUI currentGuessStateText = null;

        [SerializeField][Required] private GameplayStateModel gameplayStateModel = null;

        [SerializeField][Required] private Button backButton = null;

        public event Action BackButtonClicked;

        private void OnEnable() {
            backButton.onClick.AddListener(OnBackButtonClicked);
        }

        private void OnDisable() {
            backButton.onClick.RemoveListener(OnBackButtonClicked);
        }

        private void OnBackButtonClicked() {
            BackButtonClicked?.Invoke();
        }

        public void RefreshUI() {
            winStreakCountText.text = $"Win Streak: [{gameplayStateModel.WinStreak}]";
            lossCountText.text = $"Loss Count: [{gameplayStateModel.LossCount}]";
            winCountText.text = $"Win Count: [{gameplayStateModel.WinCount}]";
            wrongAttemptsText.text = $"Incorrect Guesses: [{gameplayStateModel.ErrorCount}]";
            currentGuessStateText.text = $"{ (gameplayStateModel.CurrentWordStatus != null ? new string(gameplayStateModel.CurrentWordStatus) : "End Game") }";
        }
    }
}