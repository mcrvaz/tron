public class MatchController
{
    MatchModel model;
    MatchView view;

    public MatchController (MatchModel model, MatchView view)
    {
        this.model = model;
        this.view = view;
    }
}