using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

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
            if (gameObject != null && gameObject.transform.position.x <= settings.StartPos.x - settings.MaxObstacleDistance)
            {
                group.RemoveObstacle(gameObject);
                Object.Destroy(gameObject);
            }
        }
    }
}
