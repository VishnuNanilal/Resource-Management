using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : SceneManager
{
    private List<AsyncOperation> currentOperations = new List<AsyncOperation>();
    public void LoadLevel(int levelNumber)
    {
        AsyncOperation ao =  SceneManager.LoadSceneAsync(levelNumber);
        currentOperations.Add(ao);
        ao.completed += OnLevelLoadComplete;
    }

    public void LoadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName);
        currentOperations.Add(ao);
        ao.completed += OnLevelLoadComplete;
    }

    public void UnloadLevel(int levelNumber)
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(levelNumber);
        currentOperations.Add(ao);
        ao.completed += OnLevelUnloadComplete;
    }

    public void UnloadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName);
        currentOperations.Add(ao);
        ao.completed += OnLevelUnloadComplete;
    }
    
    private void OnLevelLoadComplete(AsyncOperation ao)
    {
        currentOperations.Remove(ao);
    }

    private void OnLevelUnloadComplete(AsyncOperation ao)
    {
        currentOperations.Remove(ao);
    }
}
