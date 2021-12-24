using System;
using System.Collections;
using UnityEngine;

public class GameInput : IDisposable
{
    public Input CurrentInput { get; private set; }

    readonly IInputProvider inputProvider;
    readonly ICoroutineRunner coroutineRunner;

    Coroutine routine;

    public GameInput (IInputProvider inputProvider, ICoroutineRunner coroutineRunner)
    {
        this.inputProvider = inputProvider;
        this.coroutineRunner = coroutineRunner;
    }

    public void Initialize ()
    {
        routine = coroutineRunner.StartCoroutine(InputRoutine());
    }

    IEnumerator InputRoutine ()
    {
        while (true)
        {
            CurrentInput = new Input(GetInputDirection());
            yield return null;
        }
    }

    InputDirection GetInputDirection ()
    {
        if (inputProvider.IsDownTriggered)
            return InputDirection.Down;

        if (inputProvider.IsUpTriggered)
            return InputDirection.Up;

        if (inputProvider.IsLeftTriggered)
            return InputDirection.Left;

        if (inputProvider.IsRightTriggered)
            return InputDirection.Right;

        return InputDirection.None;
    }

    public void Dispose ()
    {
        if (routine != null)
            coroutineRunner.StopCoroutine(routine);
    }
}
