using UnityEngine;
using VContainer;
using VContainer.Unity;

public class ApplicationInstaller : IInstaller
{
    public void Install (IContainerBuilder builder)
    {
        LifetimeScope parent = (LifetimeScope)builder.ApplicationOrigin;
        builder.Register<ApplicationModel>(Lifetime.Scoped);
        builder.Register<ApplicationController>(Lifetime.Scoped);
        builder.RegisterComponentInNewPrefab(
            Resources.Load<ApplicationView>("ApplicationView"), Lifetime.Scoped
        ).UnderTransform(parent.gameObject.transform);
    }
}
