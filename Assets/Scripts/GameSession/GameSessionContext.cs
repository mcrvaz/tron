using System;
using VContainer.Unity;

public class GameSessionContext : IInitializable, IDisposable
{
    public GameSessionModel Model { get; }
    public GameSessionView View { get; }
    public GameSessionController Controller { get; }
    public ICoroutineRunner CoroutineRunner => View;

    readonly LifetimeScope parent;
    readonly SceneLoader mainSceneLoader;

    public GameSessionContext (
        LifetimeScope parent,
        SceneLoader mainSceneLoader,
        GameSessionModel model,
        GameSessionView view,
        GameSessionController controller
    )
    {
        this.parent = parent;
        this.mainSceneLoader = mainSceneLoader;
        Model = model;
        View = view;
        Controller = controller;
    }

    public void Initialize ()
    {
        mainSceneLoader.OnSceneLoaded += HandleSceneLoaded;
        CoroutineRunner.StartCoroutine(mainSceneLoader.LoadSceneAsync());
    }

    void HandleSceneLoaded ()
    {
        UnityEngine.Debug.Log("loaded");
    }

    public void Dispose ()
    {
    }
}
