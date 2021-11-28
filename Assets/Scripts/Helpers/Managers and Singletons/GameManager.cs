using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace ResourceSimulation.Core
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] List<GameObject> managers = new List<GameObject>();

        private void Awake() {
            foreach(GameObject manager in managers)
                Instantiate(manager);
        }

        public void QuitGame()
        {
            #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }
}

