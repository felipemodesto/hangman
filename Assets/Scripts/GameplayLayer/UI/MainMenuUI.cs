using Sirenix.OdinInspector;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Hangman.GameplayLayer {

    /// <summary>
    /// UI Class to control event interaction for the Main Menu UI (Start, Options, Credits, whatever else mayt end up in those menus)
    /// </summary>
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField][Required] private Button startButton = null;
        [SerializeField][Required] private Button rulesButton = null;

        public event Action StartButtonClicked;
        public event Action RulesButtonClicked;

        private void OnEnable() {
            startButton.onClick.AddListener(OnStartButtonClicked);
            rulesButton.onClick.AddListener(OnRulesButtonClicked);
        }

        private void OnDisable() {
            startButton.onClick.RemoveListener(OnStartButtonClicked);
            rulesButton.onClick.RemoveListener(OnRulesButtonClicked);
        }

        private void OnRulesButtonClicked() {
            RulesButtonClicked?.Invoke();
        }

        //Note: Button linking is not done using Unity's UI Button Callback registration to improve code interconnection and due to distaste with that system, can expose this method if required.
        private void OnStartButtonClicked() {
            StartButtonClicked?.Invoke();
        }
    }
}