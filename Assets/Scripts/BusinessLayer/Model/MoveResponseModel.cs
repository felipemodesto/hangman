namespace Hangman.BusinessLayer {

    public enum GameplayStatus {
        Error = -1,
        None = 0,
        Playing = 1,
        Won = 2,
        Lost = 3
    }

    public struct MoveResponseModel {
        public MoveRequestModel Request;
        public bool ValidMove;
        public int KeyMatches;
        public GameplayStatus GameStatus;
        public string Message;
    }
}