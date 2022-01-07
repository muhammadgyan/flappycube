using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CubeJumper : ITickable, IFixedTickable
{
    private FlappyCubeSettings settings;
    private Rigidbody cubeRigidbody;
    private FlappyCubeGameStateChanger stateChanger;
    
    public CubeJumper(Rigidbody cubeRigidbody, FlappyCubeSettings settings, FlappyCubeGameStateChanger stateChanger)
    {
        this.settings = settings;
        this.cubeRigidbody = cubeRigidbody;
        this.stateChanger = stateChanger;
    }

    public void Tick()
    {
        if (stateChanger.GameState != EnumGameState.Dead)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                cubeRigidbody.AddForce(Vector3.up * settings.JumpForce, ForceMode.Impulse);
            }
        }
    }

    public void FixedTick()
    {
        if (stateChanger.GameState == EnumGameState.Play)
        {
            cubeRigidbody.AddForce(Physics.gravity * settings.GravityMultiplier);
        }

        cubeRigidbody.velocity = Vector3.ClampMagnitude(cubeRigidbody.velocity, settings.MaxVelocity);
    }
}
