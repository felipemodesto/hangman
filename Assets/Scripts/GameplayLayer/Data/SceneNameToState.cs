using Sirenix.OdinInspector;
using System;
using UnityEngine;
using JetBrains.Annotations;

#if UNITY_EDITOR
using UnityEditor;
using System.IO;
#endif

namespace Hangman.GameplayLayer {

    [Serializable]
    public struct SceneNameToState {
        [SerializeField][ValueDropdown("SceneNameList")] private string sceneName;
        [SerializeField] private SceneState state;

        public string SceneName => sceneName;
        public SceneState State => state;

        [UsedImplicitly]
        public SceneNameToState(string sceneName, SceneState state) {
            this.sceneName = sceneName;
            this.state = state;
        }

        //Keeping the editor code along with the class that uses it for the sake of clarity in this sample implementation. Would move into an editor folder in a real project after a first pass implementation
        //For now, just gotta go fast and keep small pieces of code in one place :)
#if UNITY_EDITOR
        private static string[] SceneNameList() {
            string[] sceneAssetGuidList = AssetDatabase.FindAssets("t:scene");

            int length = sceneAssetGuidList.Length;

            string[] sceneNameList = new string[length];

            for (int index = 0; index < length; index++) {
                sceneNameList[index] = Path.GetFileNameWithoutExtension(AssetDatabase.GUIDToAssetPath(sceneAssetGuidList[index]));
            }
            return sceneNameList;
        }
#endif
    }
}