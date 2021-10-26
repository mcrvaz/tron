using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameSessionInstaller : IInstaller
{
    public void Install (IContainerBuilder builder)
    {
        LifetimeScope parentScope = (LifetimeScope)builder.ApplicationOrigin;
        builder.Register<LifetimeScope>(x => parentScope, Lifetime.Scoped);

        builder.Register<SceneLoader>(Lifetime.Scoped).WithParameter("Main");
        builder.Register<GameSessionModel>(Lifetime.Scoped);
        builder.Register<GameSessionController>(Lifetime.Scoped);
        builder.RegisterComponentInNewPrefab(
            Resources.Load<GameSessionView>("GameSessionView"), Lifetime.Scoped
        ).UnderTransform(parentScope.gameObject.transform);
        builder.Register<GameSessionContext>(Lifetime.Scoped);
    }
}
