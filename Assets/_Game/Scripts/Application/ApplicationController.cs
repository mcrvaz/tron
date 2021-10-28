using System;

public class ApplicationController : IDisposable
{
    public GameSessionController GameSessionController { get; private set; }

    readonly ApplicationModel model;
    readonly ApplicationView view;
    readonly Func<GameSessionController> gameSessionControllerFactory;

    public ApplicationController (ApplicationModel model, ApplicationView view, Func<GameSessionController> gameSessionControllerFactory)
    {
        this.model = model;
        this.view = view;
        this.gameSessionControllerFactory = gameSessionControllerFactory;
    }

    public void Initialize ()
    {
        GameSessionController = gameSessionControllerFactory();
    }

    public void Dispose ()
    {
    }
}
