using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Hangman.BusinessLayer {

    [CreateAssetMenu(menuName = "Hangman/Business/GameSessionService")]
    public class GameSessionService : ScriptableObject {

        [SerializeField][Required] private GameplayStateModel gameplayStateModel = null;
        [SerializeField][Required] HangmanWordDictionary hangmanWordDictionary = null;
        [SerializeField][Required] GameRulesData gameRulesData = null;

        private List<string> usableWordPool = null;

        
        private string SanitizeWord(string currentWord) {
            return currentWord.ToLower().Replace("\n", "").Replace("\t", "").Replace(" ", "");
        }

        private void RefillWordPool() {
            usableWordPool = new List<string>(hangmanWordDictionary.WordList);
        }

        public bool Initialize() {
            if (gameplayStateModel == null || hangmanWordDictionary == null || gameRulesData == null) return false;

            gameplayStateModel.ConsumedCharacters = new List<char>(26);
            RefillWordPool();
            return true;
        }

        public bool StartNewGame() {
            gameplayStateModel.IsPlaying = true;

            if (usableWordPool.Count == 0) {
                RefillWordPool();
            }

            gameplayStateModel.CurrentWord = usableWordPool[UnityEngine.Random.Range(0, usableWordPool.Count-1)];
            usableWordPool.Remove(gameplayStateModel.CurrentWord);
            gameplayStateModel.CurrentWord = SanitizeWord(gameplayStateModel.CurrentWord);

            gameplayStateModel.CurrentWordStatus = new char[gameplayStateModel.CurrentWord.Length];
            for (int i = 0; i < gameplayStateModel.CurrentWordStatus.Length; i++) {
                gameplayStateModel.CurrentWordStatus[i] = '_';
            }

#if DEBUG   //Essentially I'm adding this check assumming that the CI/CD build and release processes used for release wont be configured to fully strip debug.logs from the game as that is almost never the case. :)
            Debug.Log($"Word of the game: \"{ gameplayStateModel.CurrentWord}\"");
#endif

            return true;
        }

        public bool EndGame() {
            if (gameplayStateModel.GuessedCharacterCount != gameplayStateModel.CurrentWord.Length) {
                gameplayStateModel.WinStreak = 0;
            }
            else {
                gameplayStateModel.WinStreak++;
            }

            Reset();

            return true;
        }

        private void Reset() {
            gameplayStateModel.GuessedCharacterCount = 0;
            gameplayStateModel.ErrorCount = 0;
            gameplayStateModel.CurrentWord = "";
            gameplayStateModel.CurrentWordStatus = null;
            gameplayStateModel.ConsumedCharacters.Clear();
            gameplayStateModel.IsPlaying = false;
        }

        public MoveResponseModel AttemptMove(MoveRequestModel request) {
            if (!gameplayStateModel.IsPlaying) {
                return new MoveResponseModel(){
                    Request = request,
                    ValidMove = false,
                    GameStatus = GameplayStatus.Error,
                    Message = "Game not actively running, cannot process request.",
                    KeyMatches = 0,
                };
            }

            bool invalidKey = gameplayStateModel.ConsumedCharacters.Contains(request.Key);

            if (invalidKey) {
                return new MoveResponseModel() {
                    Request = request,
                    ValidMove = false,
                    GameStatus = GameplayStatus.Error,
                    Message = "Repeated Keypress Request, move rejected.",
                    KeyMatches = 0,
                };
            }

            GameplayStatus postMoveStatus = GameplayStatus.Playing;


            int count = 0;
            int index = 0;
            foreach (char c in gameplayStateModel.CurrentWord) {
                if (c == request.Key) {
                    count++;
                    gameplayStateModel.CurrentWordStatus[index] = c;
                }

                index++;
            }
            gameplayStateModel.GuessedCharacterCount += count;

            bool wasGoodMove = count > 0;
            
            if (!wasGoodMove) {
                gameplayStateModel.ErrorCount++;
            }

            if (gameplayStateModel.GuessedCharacterCount == gameplayStateModel.CurrentWord.Length) {
                postMoveStatus = GameplayStatus.Won;
                gameplayStateModel.IsPlaying = false;
                gameplayStateModel.WinCount++;
            } else if (postMoveStatus != GameplayStatus.Won && gameplayStateModel.ErrorCount >= gameRulesData.WrongMovesForDeath) {
                postMoveStatus = GameplayStatus.Lost;
                gameplayStateModel.IsPlaying = false;
                gameplayStateModel.LossCount++;
            }

            gameplayStateModel.ConsumedCharacters.Add(request.Key);
            return new MoveResponseModel() {
                Request = request,
                ValidMove = true,
                GameStatus = postMoveStatus,
                Message = $"Good Request. {count} matches",
                KeyMatches = count,
            };
        }
    }
}