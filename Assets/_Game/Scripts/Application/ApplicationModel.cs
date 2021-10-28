using System;
using VContainer.Unity;

public class ApplicationModel : IInitializable, IDisposable
{
    public GameSessionModel GameSessionModel { get; private set; }

    readonly Func<GameSessionModel> gameSessionModelFactory;

    public ApplicationModel (Func<GameSessionModel> gameSessionModelFactory)
    {
        this.gameSessionModelFactory = gameSessionModelFactory;
    }

    public void Initialize ()
    {
        GameSessionModel = gameSessionModelFactory();
    }

    public void Dispose () { }
}
