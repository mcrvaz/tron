using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameSessionInstaller : IInstaller
{
    public void Install (IContainerBuilder builder)
    {
        builder.RegisterFactory<GameSessionModel>(
            (IObjectResolver resolver) => () => resolver.Resolve<GameSessionModel>(),
            Lifetime.Scoped
        );
        builder.Register<GameSessionModel>(Lifetime.Scoped);

        builder.RegisterFactory<GameSessionController>(
            (IObjectResolver resolver) => () => resolver.Resolve<GameSessionController>(),
            Lifetime.Scoped
        );
        builder.Register<GameSessionController>(Lifetime.Scoped);

        builder.RegisterFactory<GameSessionView>(
            (IObjectResolver resolver) => () => resolver.Resolve<GameSessionView>(),
            Lifetime.Scoped
        );
        builder.RegisterComponentInNewPrefab(
            Resources.Load<GameSessionView>("GameSessionView"), Lifetime.Scoped
        );
    }
}
