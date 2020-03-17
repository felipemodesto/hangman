using JetBrains.Annotations;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Hangman.GameplayLayer { 
    [CreateAssetMenu(menuName = "Hangman/Gameplay/VirtualKeyboardLayout")]
    public class VirtualKeyboardLayout : ScriptableObject {
        [TableList]
        [SerializeField] private List<KeyboardLayoutRow> rowList = null;
        public List<KeyboardLayoutRow> RowList => rowList;
    }


    [Serializable]
    public struct KeyboardLayoutRow {
        [SerializeField] private char[] characterList;
        public char[] CharacterList => characterList;

        [UsedImplicitly]
        public KeyboardLayoutRow(char[] characterList) {
            this.characterList = characterList;
        }
    }
}