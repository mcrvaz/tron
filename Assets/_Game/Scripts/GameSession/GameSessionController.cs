using System;

public class GameSessionController
{
    readonly GameSessionModel model;
    readonly GameSessionView view;

    public GameSessionController (
        GameSessionModel model,
        GameSessionView view
    )
    {
        this.model = model;
        this.view = view;
    }

    public void Initialize ()
    {
    }
}
