using MessagePipe;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class FlappyCubeLifetimeScope : LifetimeScope
{
    public Cube Cube;
    public FlappyCubeSettings Settings;
    
    [SerializeField]
    private Obstacle ObstaclePrefab;

    [SerializeField]
    private View_ScoreText ScoreText;

    protected override void Configure(IContainerBuilder builder)
    {
        var options = builder.RegisterMessagePipe(/* configure option */);
        
        // Setup GlobalMessagePipe to enable diagnostics window and global function
        builder.RegisterBuildCallback(c => GlobalMessagePipe.SetProvider(c.AsServiceProvider()));

        // RegisterMessageBroker: Register for IPublisher<T>/ISubscriber<T>, includes async and buffered.
        builder.RegisterMessageBroker<string>(options);
        builder.RegisterMessageBroker<EnumGameState>(options);

        builder.RegisterComponentInHierarchy<View_InstructionPanel>();
        builder.RegisterComponent(Cube);
        builder.RegisterInstance(Cube.gameObject);
        builder.RegisterInstance(Cube.gameObject.GetComponent<Rigidbody>());
        builder.RegisterInstance(Settings);
        builder.RegisterInstance(ScoreText);

        builder.RegisterInstance(new FlappyCubeGameStateChanger());
        builder.RegisterInstance(new ObstacleGroup());
        //
        builder.Register<GameInitializer>(Lifetime.Scoped).AsImplementedInterfaces();
        builder.RegisterEntryPoint<PointScoring>();
        
        builder.RegisterEntryPoint<CubeJumper>();
        builder.RegisterEntryPoint<ObstacleCollision>();

        //For the class to be registered as well, we need to ad AsSelf
        builder.RegisterEntryPoint<ObstacleMover>().AsSelf();
       
        builder.RegisterEntryPoint<ObstacleSpawner>();
        builder.RegisterEntryPoint<ObstacleDespawner>();
        
        builder.RegisterComponentInNewPrefab(ObstaclePrefab, Lifetime.Scoped);
        builder.RegisterFactory<Obstacle>(resolver =>
        {
            return (() =>
            {
                Obstacle newPrefab = resolver.Instantiate(ObstaclePrefab);
                return newPrefab;
            });
            
        }, Lifetime.Singleton);
    }
}
