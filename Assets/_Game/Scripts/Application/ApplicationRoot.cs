using UnityEngine;
using VContainer;
using VContainer.Unity;

public class ApplicationRoot
{
    public static ApplicationContext ApplicationContext { get; private set; }

    [RuntimeInitializeOnLoadMethodAttribute(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Main ()
    {
        LifetimeScope rootScope = LifetimeScope.Create(Install);
        rootScope.name = "Root";
        GameObject.DontDestroyOnLoad(rootScope);

        ApplicationContext = rootScope.Container.Resolve<ApplicationContext>();
        ApplicationContext.Initialize();
    }

    static void Install (IContainerBuilder builder)
    {
        builder.Register<ApplicationContext>(x =>
        {
            LifetimeScope parent = (LifetimeScope)builder.ApplicationOrigin;
            LifetimeScope scope = parent.CreateChildFromPrefab(
                Resources.Load<ApplicationContext>("ApplicationContext"),
                new ApplicationInstaller()
            );
            scope.Container.Inject(scope);
            return (ApplicationContext)scope;
        }, Lifetime.Scoped);
    }
}
