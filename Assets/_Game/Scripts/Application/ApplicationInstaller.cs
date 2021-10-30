using UnityEngine;
using VContainer;
using VContainer.Unity;

public class ApplicationInstaller : IInstaller
{
    public void Install (IContainerBuilder builder)
    {
        LifetimeScope parent = (LifetimeScope)builder.ApplicationOrigin;
        builder.Register<LifetimeScope>(x => parent, Lifetime.Scoped);
        // builder.Register<ApplicationContext>(Lifetime.Scoped);
        builder.Register<ApplicationModel>(Lifetime.Scoped);
        builder.Register<ApplicationController>(Lifetime.Scoped);
        builder.RegisterComponentInNewPrefab(
            Resources.Load<ApplicationView>("ApplicationView"), Lifetime.Scoped
        ).UnderTransform(parent.gameObject.transform);

        builder.RegisterFactory<GameSessionContext>(
            x => () => x.Resolve<GameSessionContext>(),
            Lifetime.Scoped
        );
        builder.Register<GameSessionContext>(x =>
        {
            LifetimeScope parent = (LifetimeScope)builder.ApplicationOrigin;
            LifetimeScope scope = parent.CreateChildFromPrefab(
                Resources.Load<GameSessionContext>("GameSessionContext"),
                new GameSessionInstaller()
            );
            scope.Container.Inject(scope);
            return (GameSessionContext)scope;
        }, Lifetime.Scoped);
    }
}
