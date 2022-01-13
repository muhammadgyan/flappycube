using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class CubeMover : IInitializable, ITickable
{
    private FlappyCubeSettings settings;
    private GameObject Cube;

    public CubeMover(GameObject cube, FlappyCubeSettings settings)
    {
        this.Cube = cube;
        this.settings = settings;
    }
    
    public void Initialize()
    {
        Cube.transform.position = settings.StartPos;
    }

    public void Tick()
    {
        Cube.transform.position += Cube.transform.right * settings.MoveSpeed * Time.deltaTime;
    }
}
