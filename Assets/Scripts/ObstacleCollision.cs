using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObstacleCollision
{
    private Rigidbody cube;
    private FlappyCubeGameStateChanger stateChanger;
    public ObstacleCollision(Rigidbody cube, FlappyCubeGameStateChanger stateChanger)
    {
        this.stateChanger = stateChanger;
        this.cube = cube;
    }
    
    public void Collide()
    {
        if (stateChanger.GameState == EnumGameState.Play)
        {
            cube.velocity = Vector3.zero;
            stateChanger.ChangeState(EnumGameState.Dead);
        }
    }
}
