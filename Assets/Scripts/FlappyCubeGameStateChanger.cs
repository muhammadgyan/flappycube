using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnumGameState
{
    Idle,
    Play,
    Dead
}

public class FlappyCubeGameStateChanger
{
    public EnumGameState GameState { get; private set; }
 
    public void ChangeState(EnumGameState state)
    {
        GameState = state;
        Debug.Log("Change State : " + GameState);
    }
}
