using System;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;

public class GameSessionContext : LifetimeScope
{
    [Inject]
    public GameSessionModel Model { get; private set; }
    [Inject]
    public GameSessionView View { get; private set; }
    [Inject]
    public GameSessionController Controller { get; private set; }
    [Inject]
    public Func<MatchContext> MatchContextFactory { get; private set; }
    [Inject]
    public SceneLoader SceneLoader { get; private set; }

    public MatchContext MatchContext { get; private set; }

    public void Initialize ()
    {
        SceneLoader.OnSceneLoaded += HandleSceneLoaded;
        StartCoroutine(SceneLoader.LoadSceneAsync("Level1"));
    }

    void HandleSceneLoaded (Scene scene)
    {
        MatchContext = MatchContextFactory();
    }
}