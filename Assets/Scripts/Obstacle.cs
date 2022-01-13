using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class Obstacle : MonoBehaviour
{
    private FlappyCubeSettings settings;    
    
    [Inject]
    public void Init(ObstacleMover mover, FlappyCubeSettings settings)
    {
        this.settings = settings;
    }

    void Start()
    {
        Vector3 startPos = settings.ObstacleStartPos;
        startPos.y = settings.RandomYPos[UnityEngine.Random.Range(0, settings.RandomYPos.Length)];
        this.transform.position = startPos;
    }

    // public class Factory : PlaceholderFactory<Obstacle>
    // {
    //     public override Obstacle Create()
    //     {
    //         return base.Create();
    //     }
    // }
}
