using UnityEngine;
using VContainer;
using VContainer.Unity;

public class MatchInstaller : IInstaller
{
    public void Install (IContainerBuilder builder)
    {
        LifetimeScope parent = (LifetimeScope)builder.ApplicationOrigin;
        // builder.Register<LifetimeScope>(x => parent, Lifetime.Scoped);
        // builder.Register<MatchInstaller>(x => this, Lifetime.Scoped).As<IInstaller>();
        // builder.Register<SceneLoader>(Lifetime.Scoped);

        builder.Register<LifetimeScope>(x => parent, Lifetime.Scoped);

        builder.RegisterFactory<MatchModel>(
            (IObjectResolver resolver) => () => resolver.Resolve<MatchModel>(),
            Lifetime.Scoped
        );
        builder.Register<MatchModel>(Lifetime.Scoped);

        builder.RegisterFactory<MatchController>(
            (IObjectResolver resolver) => () => resolver.Resolve<MatchController>(),
            Lifetime.Scoped
        );
        builder.Register<MatchController>(Lifetime.Scoped);

        builder.RegisterFactory<MatchView>(
            (IObjectResolver resolver) => () => resolver.Resolve<MatchView>(),
            Lifetime.Scoped
        );

        builder.RegisterComponentInNewPrefab<PlayerCharacterView>(
            Resources.Load<PlayerCharacterView>("PlayerCharacterView"),
            Lifetime.Scoped
        );
        builder.RegisterComponentInHierarchy<MatchView>();
        builder.RegisterComponentInHierarchy<MatchContext>();
    }
}