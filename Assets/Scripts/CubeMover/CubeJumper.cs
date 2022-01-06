using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CubeJumper : ITickable, IFixedTickable
{
    private FlappyCubeSettings settings;
    private Rigidbody cubeRigidbody;
    
    public CubeJumper(Rigidbody cubeRigidbody, FlappyCubeSettings settings)
    {
        this.settings = settings;
        this.cubeRigidbody = cubeRigidbody;
    }

    public void Tick()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cubeRigidbody.AddForce(Vector3.up * settings.JumpForce, ForceMode.Impulse);
        }
    }

    public void FixedTick()
    {
        cubeRigidbody.AddForce(Physics.gravity * settings.GravityMultiplier);
    }
}
