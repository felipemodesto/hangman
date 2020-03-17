using Sirenix.OdinInspector;
using UnityEngine;
using Hangman.BusinessLayer;
using System;

namespace Hangman.GameplayLayer {
    public class GameplayController : MonoBehaviour {
        [SerializeField][Required] private VirtualKeyboardUI keyboardUI = null;
        [SerializeField][Required] private HudUI hudUI = null;
        [SerializeField][Required] private GameplayAPI gameplayAPI = null;
        [SerializeField][Required] private HangmanUI hangmanUI = null;

        [SerializeField][Required] private EndGamePopupUI victoryUI = null;
        [SerializeField][Required] private EndGamePopupUI lossUI = null;

        // Start is called before the first frame update
        void Start() {
            Initialize();
        }

        private void Initialize() {

            bool isReady = gameplayAPI.Initialize();

            Debug.Assert(isReady == true, "Game Initialization Failed");

            gameplayAPI.RequestNewGame();
            RefreshUI();
        }

        private void Reset() {
            victoryUI.Deactivate();
            lossUI.Deactivate();
            keyboardUI.Reset();
            RefreshUI();
        }

        private void OnEnable() {
            keyboardUI.KeyPressed += OnKeyPressed;
            victoryUI.RestartButtonClicked += OnEndGamePanelRestartButtonPressed;
            lossUI.RestartButtonClicked += OnEndGamePanelRestartButtonPressed;
            hudUI.BackButtonClicked += OnBackButtonPressed;
        }

        private void OnDisable() {
            keyboardUI.KeyPressed -= OnKeyPressed;
            victoryUI.RestartButtonClicked -= OnEndGamePanelRestartButtonPressed;
            lossUI.RestartButtonClicked -= OnEndGamePanelRestartButtonPressed;
            hudUI.BackButtonClicked -= OnBackButtonPressed;
        }

        private void OnBackButtonPressed() {
            gameplayAPI.RequestEndGame();
            Reset();
            GlobalContext.Instance.SceneManager.TransitionTo(SceneState.MainMenu);
        }

        private void OnEndGamePanelRestartButtonPressed()
        {
            Reset();
            gameplayAPI.RequestNewGame();
            RefreshUI();
        }

        private void OnKeyPressed(char key) {
            ProcessKeyInput(key);
        }

        private void ProcessKeyInput(char key) {
            MoveResponseModel response = gameplayAPI.RequestMoveAttempt(new MoveRequestModel(key));

            if (response.ValidMove) {

                RefreshUI();
                keyboardUI.DisableKey(key);

                if (response.GameStatus == GameplayStatus.Won || response.GameStatus == GameplayStatus.Lost) {

                    if (response.GameStatus == GameplayStatus.Won) {
                        victoryUI.Activate();
                    } else {
                        lossUI.Activate();
                    }

                    RefreshUI();
                    gameplayAPI.RequestEndGame();
                }
            }
        }

        private void RefreshUI() {
            hudUI.RefreshUI();
            hangmanUI.RefreshUI();
        }
    }
}