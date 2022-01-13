using System.Collections;
using System.Collections.Generic;
using MessagePipe;
using UnityEngine;
using VContainer.Unity;

public class GameInitializer : IInitializable, ITickable
{
    private FlappyCubeGameStateChanger _stateChanger;
    private IPublisher<EnumGameState> statePublisher;
    public GameInitializer(FlappyCubeGameStateChanger stateChanger, IPublisher<EnumGameState> statePublisher)
    {
        this._stateChanger = stateChanger;
        this.statePublisher = statePublisher;
    }
    
    public void Initialize()
    {
        _stateChanger.ChangeState(EnumGameState.Idle);
        statePublisher.Publish(EnumGameState.Idle);
    }

    public void Tick()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _stateChanger.GameState == EnumGameState.Idle)
        {
            _stateChanger.ChangeState(EnumGameState.Play);
            statePublisher.Publish(EnumGameState.Play);
        }
    }

}
