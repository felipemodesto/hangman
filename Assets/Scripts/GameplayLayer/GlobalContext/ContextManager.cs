using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Hangman.GameplayLayer {

    public class ContextManager : MonoBehaviour {

        [SerializeField] private SceneNameToStateList stateList = null;

        private SceneState currentState = SceneState.None;

        public SceneState CurrentState => currentState;

        public event Action<SceneState, SceneState> OnExitState = null;

        public event Action<SceneState, SceneState> OnEnterState = null;

        public void TransitionTo(SceneState state, bool allowReload = false) {
            if (currentState == state && !allowReload) {
                Debug.LogWarning("Warning: Attempting to reload a scene without properly requesting said feature.");
                return;
            }

            StartCoroutine(LoadScenesCoroutine(state));
        }

        private IEnumerator LoadScenesCoroutine(SceneState state) {

            OnExitState?.Invoke(currentState, state);
            
            //Loading to Empty Scene to avoid memory bloat during cross-load
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(stateList[SceneState.Empty].SceneName);
            while (!asyncLoad.isDone) {
                yield return null;
            }

            //Actually loading new scene
            asyncLoad = SceneManager.LoadSceneAsync(stateList[state].SceneName, LoadSceneMode.Single);
            while (!asyncLoad.isDone) {
                yield return null;
            }

            OnEnterState?.Invoke(currentState, state);
            currentState = state;
        }
    }
}