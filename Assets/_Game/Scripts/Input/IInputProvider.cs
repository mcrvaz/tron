public interface IInputProvider
{
    bool IsDownTriggered { get; }
    bool IsUpTriggered { get; }
    bool IsLeftTriggered { get; }
    bool IsRightTriggered { get; }
}
