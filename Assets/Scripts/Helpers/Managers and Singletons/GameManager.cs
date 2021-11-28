using UnityEditor;

namespace ResourceSimulation.Core
{
    public class GameManager : Singleton<GameManager>
    {
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

