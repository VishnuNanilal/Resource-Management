using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace ResourceSimulation.Core
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] List<GameObject> managers = new List<GameObject>();

        protected override void Awake() {
            base.Awake();
            foreach(GameObject manager in managers)
            {
                GameObject go = Instantiate(manager);
                go.transform.parent = gameObject.transform.parent;
            }
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

