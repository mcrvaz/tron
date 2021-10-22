using System;

public class GameSessionContext : IDisposable
{
    public GameSessionModel Model { get; }
    public GameSessionView View { get; }
    public GameSessionController Controller { get; }
    public ICoroutineRunner CoroutineRunner => View;

    public GameSessionContext (
        GameSessionModel model,
        GameSessionView view,
        GameSessionController controller
    )
    {
        Model = model;
        View = view;
        Controller = controller;
    }

    public void Initialize ()
    {
        // View.Initialize();
        // Model.Initialize();
        // Controller.Initialize();
    }

    public void Dispose ()
    {
    }
}
