using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObstacleSpawner : ITickable
{
    private FlappyCubeSettings _settings;
    float _timeToNextSpawn;
    float _timeIntervalBetweenSpawns;
    private Obstacle.Factory obstacleFactory;
    private ObstacleGroup group;
    
    public ObstacleSpawner(FlappyCubeSettings settings, Obstacle.Factory obsFactory, ObstacleGroup group)
    {
        this._settings = settings;
        _timeToNextSpawn = settings.ObstacleSpawnTimer;
        _timeIntervalBetweenSpawns = settings.ObstacleSpawnTimer;
        obstacleFactory = obsFactory;
        this.group = group;
    }
    
    public void Tick()
    {
        _timeToNextSpawn -= Time.deltaTime;
        if (_timeToNextSpawn <= 0)
        {
            _timeToNextSpawn = _timeIntervalBetweenSpawns;
            SpawnNext();
        }
    }
    
    public void SpawnNext()
    {
        var asteroid = obstacleFactory.Create();
        group.AddObstacle(asteroid.gameObject);
    }
}

public class ObstacleGroup
{
    public List<GameObject> Obstacles = new List<GameObject>();
        
    public void AddObstacle(GameObject go)
    {
        if (!Obstacles.Contains(go))
        {
            Obstacles.Add(go);
        }
    }

    public void RemoveObstacle(GameObject go)
    {
        if (Obstacles.Contains(go))
        {
            Obstacles.Remove(go);
        }
    }
}
