using VContainer;
using VContainer.Unity;

public class RootInstaller : IInstaller
{
    public void Install (IContainerBuilder builder)
    {
        new ApplicationInstaller().Install(builder);
        new GameSessionInstaller().Install(builder);
    }
}