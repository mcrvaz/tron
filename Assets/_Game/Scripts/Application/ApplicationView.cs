using System;
using UnityEngine;
using VContainer;

public class ApplicationView : MonoBehaviour, ICoroutineRunner
{
    public GameSessionView GameSessionView { get; private set; }

    [Inject]
    readonly Func<GameSessionView> gameSessionViewFactory;

    public void Initialize ()
    {
        GameSessionView = gameSessionViewFactory();
        GameSessionView.transform.SetParent(transform);
    }
}
