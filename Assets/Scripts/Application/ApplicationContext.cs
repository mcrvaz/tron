using System;
using VContainer;
using VContainer.Unity;

public class ApplicationContext : IInitializable, IDisposable
{
    public GameSessionContext GameSession { get; private set; }
    public ApplicationModel Model { get; }
    public ApplicationView View { get; }
    public ApplicationController Controller { get; }
    public ICoroutineRunner CoroutineRunner => View;

    readonly LifetimeScope parent;
    readonly IInstaller gameSessionInstaller;

    public ApplicationContext (
        LifetimeScope parent,
        IInstaller gameSessionInstaller,
        ApplicationModel model,
        ApplicationView view,
        ApplicationController controller
    )
    {
        this.parent = parent;
        this.gameSessionInstaller = gameSessionInstaller;
        Model = model;
        View = view;
        Controller = controller;
    }

    public void Initialize ()
    {
        UnityEngine.Debug.Log("alo");

        LifetimeScope child = parent.CreateChild(gameSessionInstaller);
        child.name = "GameSessionScope";
        GameSession = child.Container.Resolve<GameSessionContext>();
        GameSession.Initialize();
    }

    public void Dispose ()
    {
    }
}
