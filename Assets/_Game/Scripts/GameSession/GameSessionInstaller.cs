using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameSessionInstaller : IInstaller
{
    public void Install (IContainerBuilder builder)
    {
        LifetimeScope parent = (LifetimeScope)builder.ApplicationOrigin;
        builder.Register<LifetimeScope>(x => parent, Lifetime.Scoped);
        builder.Register<MatchInstaller>(Lifetime.Scoped).As<IInstaller>();
        builder.Register<SceneLoader>(Lifetime.Scoped);

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
        ).UnderTransform(parent.transform);

        // builder.RegisterFactory<MatchContext>(
        //     x => () => x.Resolve<MatchContext>(),
        //     Lifetime.Scoped
        // );
        // builder.Register<MatchContext>(x =>
        // {
        //     LifetimeScope parent = (LifetimeScope)builder.ApplicationOrigin;
        //     LifetimeScope scope = parent.CreateChildFromPrefab(
        //         Resources.Load<MatchContext>("MatchContext"),
        //         new MatchInstaller()
        //     );
        //     scope.Container.Inject(scope);
        //     return (MatchContext)scope;
        // }, Lifetime.Scoped);
        builder.RegisterComponentInHierarchy<MatchContext>();
    }
}
