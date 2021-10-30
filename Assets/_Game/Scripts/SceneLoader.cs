using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;

public class SceneLoader
{
    public event Action<Scene> OnSceneLoaded;

    readonly IInstaller installer;
    readonly LifetimeScope parent;

    public SceneLoader (LifetimeScope parent, IInstaller installer)
    {
        this.installer = installer;
        this.parent = parent;
    }

    public void LoadScene (string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        OnSceneLoaded?.Invoke(SceneManager.GetSceneByName(sceneName));
    }

    public IEnumerator LoadSceneAsync (string sceneName)
    {
        using (LifetimeScope.EnqueueParent(parent))
        using (LifetimeScope.Enqueue(installer))
        {
            AsyncOperation loading = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            while (!loading.isDone)
                yield return null;
            OnSceneLoaded?.Invoke(SceneManager.GetSceneByName(sceneName));
        }
    }
}
