using UnityEngine;

namespace Hangman.BusinessLayer {
    [CreateAssetMenu(menuName = "Hangman/Business/GameRulesData")]
    public class GameRulesData : ScriptableObject {
        [SerializeField] [Range(1, 25)] private int wrongMovesForDeath = 0;
        public int WrongMovesForDeath => wrongMovesForDeath;
    }
}