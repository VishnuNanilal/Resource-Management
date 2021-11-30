using UnityEngine;
using System.Collections.Generic;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ResourceSimulation.Core
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] List<GameObject> managers = new List<GameObject>();

        public static event Action SaveEvent;
        public static event Action LoadEvent;

        protected override void Awake() {
            base.Awake();

            foreach(GameObject manager in managers)
            {
                GameObject go = Instantiate(manager);
                go.transform.parent = gameObject.transform.parent;
            }
        }

        public void SaveAll()
        {
            SaveEvent();
        }

        public void LoadAll()
        {
            LoadEvent();
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

