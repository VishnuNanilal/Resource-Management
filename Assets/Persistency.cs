using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ResourceSimulation.Core
{
    public class Persistency : Singleton<Persistency>
    {
        protected override void Awake() {
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }
    }
}

