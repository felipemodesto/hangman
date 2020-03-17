using Hangman.BusinessLayer;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Hangman.GameplayLayer {
    public class HangmanUI : MonoBehaviour
    {
        [SerializeField][Required] List<GameObject> hangmanGameObjects = null;
        [SerializeField][Required] GameplayStateModel gameStateModel = null;

        public void RefreshUI() {
            for(int index = 0; index < hangmanGameObjects.Count; index++) {
                if (index + 1 <= gameStateModel.ErrorCount) {
                    hangmanGameObjects[index].SetActive(true);
                }
                else {
                    hangmanGameObjects[index].SetActive(false);
                }
            }
        }
    }
}
