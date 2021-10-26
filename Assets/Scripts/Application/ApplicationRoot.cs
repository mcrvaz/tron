using UnityEngine;
using VContainer;
using VContainer.Unity;

public class ApplicationRoot
{
    public static ApplicationContext ApplicationContext { get; private set; }

    [RuntimeInitializeOnLoadMethodAttribute(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Initialize ()
    {
        LifetimeScope scope = LifetimeScope.Create(new ApplicationInstaller().Install);
        ApplicationContext = scope.Container.Resolve<ApplicationContext>();
        ApplicationContext.Initialize();
    }
}