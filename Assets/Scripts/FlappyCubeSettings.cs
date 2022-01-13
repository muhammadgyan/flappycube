using UnityEngine;

[CreateAssetMenu(fileName = "CubeMoverSettings", menuName = "FlappyCubeSettings")]
public class FlappyCubeSettings : ScriptableObject
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
}