using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

public class TestObstacleMover : IStartable
{
    private ObstacleMover mover;
    
    public TestObstacleMover(ObstacleMover mover)
    {
        this.mover = mover;
    }
    public void Start()
    {
        Debug.Log(mover);
    }
}
