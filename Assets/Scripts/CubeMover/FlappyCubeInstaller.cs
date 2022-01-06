using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FlappyCubeInstaller : MonoInstaller
{
    [SerializeField]
    private GameObject Cube;

    [SerializeField]
    private Obstacle ObstaclePrefab;
    
    public override void InstallBindings()
    {
        Container.BindInstance(Cube).WithId("Player").AsSingle();
        Container.BindInstance(Cube.GetComponent<Rigidbody>()).AsSingle();

        // Container.BindInterfacesAndSelfTo<CubeMover>().AsSingle();
        Container.BindInterfacesAndSelfTo<CubeJumper>().AsSingle();

        Container.Bind<ObstacleGroup>().AsSingle();
        Container.BindInterfacesAndSelfTo<ObstacleSpawner>().AsSingle();
        
        Container.BindFactory<Obstacle, Obstacle.Factory>()
            .FromComponentInNewPrefab(ObstaclePrefab)
            .WithGameObjectName("Obstacle")
            .UnderTransformGroup("Obstacles");

        Container.BindInterfacesAndSelfTo<ObstacleMover>().AsSingle();
        Container.BindInterfacesAndSelfTo<ObstacleDespawner>().AsSingle();
    }
}

