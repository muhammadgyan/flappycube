using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObstacleDespawner : ITickable
{
    private FlappyCubeSettings settings;
    private ObstacleGroup group;
    public ObstacleDespawner(FlappyCubeSettings settings, ObstacleGroup group)
    {
        this.settings = settings;
        this.group = group;
    }
    
    public void Tick()
    {
        GameObject[] obstacles = @group.Obstacles.ToArray();
        foreach (GameObject gameObject in obstacles)
        {
            if (gameObject.transform.position.x <= settings.StartPos.x - settings.MaxObstacleDistance)
            {
                group.RemoveObstacle(gameObject);
                GameObject.Destroy(gameObject);
            }
        }
    }
}
