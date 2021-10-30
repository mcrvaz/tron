using System;
using System.Collections;
using UnityEngine;
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
        StartCoroutine(LoadSceneRoutine("Level1"));
    }

    IEnumerator LoadSceneRoutine (string sceneName)
    {
        AsyncOperation loading = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        while (!loading.isDone)
            yield return null;
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
        MatchContext = MatchContextFactory();
        MatchContext.transform.parent = null;
        SceneManager.MoveGameObjectToScene(MatchContext.gameObject, SceneManager.GetActiveScene());
        MatchContext.Build();
        MatchContext.Container.Inject(MatchContext);
        MatchContext.Initialize();
    }
}