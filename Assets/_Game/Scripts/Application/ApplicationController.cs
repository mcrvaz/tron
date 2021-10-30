using System;

public class ApplicationController : IDisposable
{
    readonly ApplicationModel model;
    readonly ApplicationView view;

    public ApplicationController (ApplicationModel model, ApplicationView view)
    {
        this.model = model;
        this.view = view;
    }

    public void Initialize ()
    {
    }

    public void Dispose ()
    {
    }
}
