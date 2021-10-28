using UnityEngine;
using VContainer;
using VContainer.Unity;

public class ApplicationRoot
{
    public static ApplicationModel Model { get; private set; }
    public static ApplicationView View { get; private set; }
    public static ApplicationController Controller { get; private set; }

    [RuntimeInitializeOnLoadMethodAttribute(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Main ()
    {
#if UNITY_EDITOR || DEVELOPMENT_BUILD
        VContainerSettings.Instance.EnableDiagnostics = true;
#else
        VContainerSettings.Instance.EnableDiagnostics = false;
#endif

        LifetimeScope scope = LifetimeScope.Create(new RootInstaller().Install);
        scope.name = "ApplicationContext";
        GameObject.DontDestroyOnLoad(scope);
        Instantiate(scope);
        Initialize();
    }

    static void Instantiate (LifetimeScope scope)
    {
        Model = scope.Container.Resolve<ApplicationModel>();
        View = scope.Container.Resolve<ApplicationView>();
        Controller = scope.Container.Resolve<ApplicationController>();
    }

    static void Initialize ()
    {
        View.Initialize();
        Model.Initialize();
        Controller.Initialize();
    }
}