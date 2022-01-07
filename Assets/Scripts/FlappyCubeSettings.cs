using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "CubeMoverSettings", menuName = "Installers/FlappyCubeSettings")]
public class FlappyCubeSettings : ScriptableObjectInstaller<FlappyCubeSettings>
{
    public Vector3 StartPos;
    public float MoveSpeed;

    public float GravityMultiplier;
    public float JumpForce;
    public float MaxVelocity;
    
    public Vector3 ObstacleStartPos;
    public float[] RandomYPos;
    public float MaxObstacleDistance;
    
    public float ObstacleMoveSpeed;
    public float ObstacleSpawnTimer;
    public override void InstallBindings()
    {
        Container.BindInstance(this);
    }
}