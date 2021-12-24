using VContainer;
using VContainer.Unity;

public class MatchContext : LifetimeScope
{
    [Inject]
    public MatchModel Model { get; private set; }
    [Inject]
    public MatchView View { get; private set; }
    [Inject]
    public MatchController Controller { get; private set; }

    public void Initialize ()
    {
        Model.Initialize();
    }
}
