namespace Hangman.BusinessLayer {
    public struct MoveRequestModel {
        private char key;

        public char Key => key;

        public MoveRequestModel(char key) {
            this.key = key;
        }
    }
}
