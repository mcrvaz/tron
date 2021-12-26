public enum InputDirection
{
    None = 0,
    Up = 1,
    Down = 2,
    Left = 3,
    Right = 4,
}

public static class InputDirectionExtensions
{
    public static bool IsOpposite (this InputDirection current, InputDirection other)
        => current switch
        {
            InputDirection.Up => other == InputDirection.Down,
            InputDirection.Down => other == InputDirection.Up,
            InputDirection.Left => other == InputDirection.Right,
            InputDirection.Right => other == InputDirection.Left,
            _ => false,
        };
}
