using System;
using UnityEngine.InputSystem;

public class InputWrapper : IInputProvider
{
    public bool IsDownTriggered => gameplayAction.Down.triggered;
    public bool IsUpTriggered => gameplayAction.Up.triggered;
    public bool IsLeftTriggered => gameplayAction.Left.triggered;
    public bool IsRightTriggered => gameplayAction.Right.triggered;

    readonly InputActions.GameplayActions gameplayAction;

    public InputWrapper (InputActions actions)
    {
        gameplayAction = actions.Gameplay;
        gameplayAction.Enable();
    }
}
