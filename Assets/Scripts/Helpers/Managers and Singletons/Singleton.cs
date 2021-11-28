using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ResourceSimulation.Core
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        private static T instance = null;

        public static T Instance
        {
            get { return instance; }
        }

        private void Awake()
        {
            if (instance != null)
            {
                Debug.Log("Singleton instance " + typeof(T) + " trying multiple instantiation.");
                return;
            }
            instance = (T)this;
        }
    }
}
