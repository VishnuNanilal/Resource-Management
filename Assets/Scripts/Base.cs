using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A special building that hold a static reference so it can be found by other script easily (e.g. for Unit to go back
/// to it)
/// </summary>
public class Base : Building
{ 
    public static Base Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public int GetCurrentAmount()
    {
        return m_CurrentAmount;
    }

    private void Update() {
        print(m_CurrentAmount);
    }
}
