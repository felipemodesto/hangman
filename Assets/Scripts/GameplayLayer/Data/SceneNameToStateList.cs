using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Hangman.GameplayLayer {

    [CreateAssetMenu(menuName = "Hangman/Gameplay/ScenenameToStateList")]
    public class SceneNameToStateList : ScriptableObject
    {
        [SerializeField] private List<SceneNameToState> list = null;

        public SceneNameToState this[SceneState state] => list.FirstOrDefault(x => x.State.Equals(state));
    }
}