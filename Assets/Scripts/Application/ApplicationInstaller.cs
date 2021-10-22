using UnityEngine;
using VContainer;
using VContainer.Unity;

public class ApplicationInstaller : IInstaller
{
    public void Install (IContainerBuilder builder)
    {
        LifetimeScope parentScope = (LifetimeScope)builder.ApplicationOrigin;
        builder.Register<LifetimeScope>(x => parentScope, Lifetime.Scoped);
        builder.Register<IInstaller, GameSessionInstaller>(Lifetime.Scoped);
        builder.Register<SceneLoader>(Lifetime.Scoped).WithParameter("Main");
        builder.Register<ApplicationContext>(Lifetime.Scoped);
        builder.Register<ApplicationModel>(Lifetime.Scoped);
        builder.Register<ApplicationController>(Lifetime.Scoped);
        builder.RegisterComponentInNewPrefab(
            Resources.Load<ApplicationView>("ApplicationView"), Lifetime.Scoped
        ).UnderTransform(parentScope.gameObject.transform);
    }
}
