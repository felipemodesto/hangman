using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hangman.BusinessLayer {
    /// <summary>
    /// This is the container for all the words. It's a "dictionary" as in a group of words, not the actual data structure
    /// Note that words are stored within a scriptable object for ease of editing and to make it simple to link the data wherever its required
    /// Note that in an actual deployed game, this data (along with other relevant data) would be stored and referenced via AddressableAssets so that game balancing and content could be updated from a remote server without a need for a binary update
    /// </summary>
    [CreateAssetMenu(menuName = "Hangman/Business/HangmanWordDictionary")]
    public class HangmanWordDictionary : ScriptableObject
    {
        [SerializeField] private List<string> wordList = null;
        public List<string> WordList => wordList;
    }
}