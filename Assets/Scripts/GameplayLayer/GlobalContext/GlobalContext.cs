using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hangman.GameplayLayer {

    public class GlobalContext : MonoBehaviour
    {
        public static GlobalContext Instance = null;

        [SerializeField] [Required] private ContextManager sceneManager = null;

        public ContextManager SceneManager => sceneManager;

        private void Awake() {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

}