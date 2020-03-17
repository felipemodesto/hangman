using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Hangman.BusinessLayer {
    [CreateAssetMenu(menuName = "Hangman/Business/GameplayStateModel")]
    public class GameplayStateModel : ScriptableObject {
        [NonSerialized][ShowInInspector][ReadOnly] protected List<char> consumedCharacters = null;
        [NonSerialized][ShowInInspector][ReadOnly] protected char[] currentWordStatus = null;
        [NonSerialized][ShowInInspector][ReadOnly] protected bool isPlaying = false;
        [NonSerialized][ShowInInspector][ReadOnly] protected string currentWord = "";
        [NonSerialized][ShowInInspector][ReadOnly] protected int guessedCharacterCount = 0;
        [NonSerialized][ShowInInspector][ReadOnly] protected int winStreak = 0;
        [NonSerialized][ShowInInspector][ReadOnly] protected int winCount = 0;
        [NonSerialized][ShowInInspector][ReadOnly] protected int lossCount = 0;
        [NonSerialized][ShowInInspector][ReadOnly] protected int errorCount = 0;


        public List<char> ConsumedCharacters {
            set { consumedCharacters = value; }
            get { return consumedCharacters; }
        }
        public char[] CurrentWordStatus {
            set { currentWordStatus = value; }
            get { return currentWordStatus; }
        }
        public bool IsPlaying {
            set { isPlaying = value; }
            get { return isPlaying; }
        }
        public string CurrentWord {
            set { currentWord = value; }
            get { return currentWord; }
        }
        public int GuessedCharacterCount {
            set { guessedCharacterCount = value; }
            get { return guessedCharacterCount; }
        }
        public int WinStreak {
            set { winStreak = value; }
            get { return winStreak; }
        }
        public int LossCount {
            set { lossCount = value; }
            get { return lossCount; }
        }
        public int WinCount {
            set { winCount = value; }
            get { return winCount; }
        }
        public int ErrorCount {
            set { errorCount = value; }
            get { return errorCount; }
        }
    }
}