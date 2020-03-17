namespace Hangman.GameplayLayer {
    public enum SceneState {
        Empty = -1,        //Not a real state, but an explicitly defined one for use with empty scene loads (memory management)
        None = 0,          //Default Value (For Sanity Checks)
        MainMenu = 1,      //Main Menu Scene
        Gameplay = 2,      //Gameplay Scene
    }
}