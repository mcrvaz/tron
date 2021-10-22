using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameSessionInstaller : IInstaller
{
    public void Install (IContainerBuilder builder)
    {
        builder.Register<GameSessionContext>(Lifetime.Scoped);
        builder.Register<GameSessionModel>(Lifetime.Scoped);
        builder.Register<GameSessionController>(Lifetime.Scoped);
        builder.RegisterComponentInNewPrefab(
            Resources.Load<GameSessionView>("GameSessionView"), Lifetime.Scoped
        );
    }
}
