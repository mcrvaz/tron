using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;

public class SceneLoader
{
    public event Action OnSceneLoaded;

    readonly string sceneName;
    readonly IInstaller installer;
    readonly LifetimeScope parent;

    public SceneLoader (LifetimeScope parent, string sceneName, IInstaller installer)
    {
        this.sceneName = sceneName;
        this.installer = installer;
        this.parent = parent;
    }

    public void LoadScene ()
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public IEnumerator LoadSceneAsync ()
    {
        using (LifetimeScope.EnqueueParent(parent))
        using (LifetimeScope.Enqueue(installer))
        {
            AsyncOperation loading = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            while (!loading.isDone)
                yield return null;
            OnSceneLoaded?.Invoke();
        }
    }
}
