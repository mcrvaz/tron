using System;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;

public class ApplicationContext : LifetimeScope
{
    [Inject]
    public ApplicationModel Model { get; private set; }
    [Inject]
    public ApplicationView View { get; private set; }
    [Inject]
    public ApplicationController Controller { get; private set; }
    [Inject]
    public Func<GameSessionContext> GameSessionContextFactory { get; private set; }

    public GameSessionContext GameSessionContext { get; private set; }

    public void Initialize ()
    {
        if (SceneManager.GetActiveScene().name != "Main")
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
        GameSessionContext = GameSessionContextFactory();
        GameSessionContext.Initialize();
    }
}
