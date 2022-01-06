using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObstacleMover : ITickable, IInitializable
{
    private FlappyCubeSettings settings;
    private ObstacleGroup group;
    
    public List<GameObject> obstacles = new List<GameObject>();
    public ObstacleMover(FlappyCubeSettings settings, ObstacleGroup group)
    {
        this.settings = settings;
        this.group = group;
    }

    public void Tick()
    {
        GameObject[] allObstacle = group.Obstacles.ToArray();
        foreach (GameObject gameObject in allObstacle)
        {
            gameObject.transform.position += Vector3.left * settings.ObstacleMoveSpeed * Time.deltaTime;

        }
    }

    public void Initialize()
    {
        
    }
}
