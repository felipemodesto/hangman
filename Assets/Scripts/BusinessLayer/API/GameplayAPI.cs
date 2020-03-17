using UnityEngine;

namespace Hangman.BusinessLayer {

    public class GameplayAPI : MonoBehaviour
    {
        [SerializeField] private GameSessionService gameSessionService = null;
        
        public bool Initialize() {
            return gameSessionService.Initialize();
        }

        public bool RequestNewGame() {
            return gameSessionService.StartNewGame();
        }

        public bool RequestEndGame() {
            return gameSessionService.EndGame();
        }

        public MoveResponseModel RequestMoveAttempt(MoveRequestModel request) {
            return gameSessionService.AttemptMove(request);
        }
    }
}