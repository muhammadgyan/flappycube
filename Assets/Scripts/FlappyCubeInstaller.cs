using System;using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class FlappyCubeInstaller : MonoInstaller
{
    [SerializeField]
    private GameObject Cube;

    [SerializeField]
    private Obstacle ObstaclePrefab;

    [SerializeField]
    private GameObject InstructionPanelObject;

    [SerializeField]
    private TextMeshProUGUI scoreText;
    
    public override void InstallBindings()
    {
        Container.BindInstance(Cube).WithId("Player").AsCached().NonLazy();
        Container.BindInstance(Cube.GetComponent<Rigidbody>()).AsCached();
        Container.BindInstance(InstructionPanelObject).WithId("InstructionPanel").AsCached();
        Container.BindInstance(scoreText).AsCached();
        
        Container.BindInterfacesAndSelfTo<FlappyCubeGameStateChanger>().AsSingle();
        Container.BindInterfacesAndSelfTo<GameInitializer>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<PointScoring>().AsSingle().NonLazy();
        
        // Container.BindInterfacesAndSelfTo<CubeMover>().AsSingle();
        Container.BindInterfacesAndSelfTo<CubeJumper>().AsSingle();
        Container.BindInterfacesAndSelfTo<ObstacleCollision>().AsSingle();
        
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

