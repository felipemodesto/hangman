using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Hangman.GameplayLayer {

    public class MainMenuNavigationController : MonoBehaviour
    {
        [SerializeField][Required] private MainMenuUI mainMenuUI = null;
        [SerializeField][Required] private RulesUI rulesUI = null;

        private void OnEnable() {
            mainMenuUI.StartButtonClicked += OnStartButtonClicked;
            mainMenuUI.RulesButtonClicked += OnRulesButtonClicked;
            rulesUI.BackButtonPressed += OnRulesBackButtonClicked;
        }

        private void OnDisable() {
            mainMenuUI.StartButtonClicked -= OnStartButtonClicked;
            mainMenuUI.RulesButtonClicked -= OnRulesButtonClicked;
            rulesUI.BackButtonPressed -= OnRulesBackButtonClicked;
        }

        private void OnRulesBackButtonClicked() {
            rulesUI.Dectivate();
        }

        private void OnRulesButtonClicked() {
            rulesUI.Activate();
        }

        private void OnStartButtonClicked() {
            GlobalContext.Instance.SceneManager.TransitionTo(SceneState.Gameplay);
        }
    }
}