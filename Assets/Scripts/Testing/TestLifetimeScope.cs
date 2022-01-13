using VContainer;
using VContainer.Unity;

public class TestLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterEntryPoint<TestEntry>().As<TestEntry>();
        builder.RegisterEntryPoint<TestInjectEntry>();
    }
}
