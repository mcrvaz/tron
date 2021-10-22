using UnityEngine;
using VContainer;
using VContainer.Unity;

public static class ApplicationRoot
{
    public static LifetimeScope ApplicationScope { get; private set; }
    public static ApplicationContext Application { get; private set; }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Initialize ()
    {
        ApplicationScope = LifetimeScope.Create(
            new ApplicationInstaller().Install
        );
        Application = ApplicationScope.Container.Resolve<ApplicationContext>();
        Application.Initialize();
    }
}
