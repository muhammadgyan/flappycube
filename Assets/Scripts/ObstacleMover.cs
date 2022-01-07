using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObstacleMover : ITickable
{
    private FlappyCubeSettings settings;
    private ObstacleGroup group;
    private FlappyCubeGameStateChanger stateChanger;
    
    public ObstacleMover(FlappyCubeSettings settings, ObstacleGroup group, FlappyCubeGameStateChanger stateChanger)
    {
        this.settings = settings;
        this.group = group;
        this.stateChanger = stateChanger;
    }

    public void Tick()
    {
        if (stateChanger.GameState == EnumGameState.Play)
        {
            GameObject[] allObstacle = group.Obstacles.ToArray();
            foreach (GameObject gameObject in allObstacle)
            {
                gameObject.transform.position += Vector3.left * settings.ObstacleMoveSpeed * Time.deltaTime;

            }
        }
    }

}
