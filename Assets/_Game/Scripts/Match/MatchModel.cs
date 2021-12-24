using System.Collections;

public class MatchModel
{
    readonly GameInput input;
    readonly ICoroutineRunner coroutineRunner;

    public MatchModel (GameInput input, ICoroutineRunner coroutineRunner)
    {
        this.input = input;
        this.coroutineRunner = coroutineRunner;
    }

    public void Initialize ()
    {
        input.Initialize();
        coroutineRunner.StartCoroutine(MatchRoutine());
    }

    IEnumerator MatchRoutine ()
    {
        while (true)
        {
            yield return null;
        }
    }
}
