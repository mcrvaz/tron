using System;
using VContainer.Unity;

public class ApplicationContext : IDisposable
{
    public ApplicationModel Model { get; }
    public ApplicationView View { get; }
    public ApplicationController Controller { get; }

    public ICoroutineRunner CoroutineRunner => View;

    readonly LifetimeScope parent;
    readonly SceneLoader mainSceneLoader;

    public ApplicationContext (
        LifetimeScope parent,
        SceneLoader mainSceneLoader,
        ApplicationModel model,
        ApplicationView view,
        ApplicationController controller
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
        // View.Initialize();
        // Model.Initialize();
        // Controller.Initialize();
        mainSceneLoader.OnSceneLoaded += HandleSceneLoaded;
        CoroutineRunner.StartCoroutine(mainSceneLoader.LoadSceneAsync());
    }

    void HandleSceneLoaded ()
    {
        mainSceneLoader.OnSceneLoaded -= HandleSceneLoaded;

    }

    public void Dispose ()
    {
    }
}
