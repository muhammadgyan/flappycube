using System;
using System.Collections;
using System.Collections.Generic;
using MessagePipe;
using UnityEngine;
using VContainer.Unity;

public class GameInitializer : IInitializable, ITickable, IDisposable
{
    private FlappyCubeGameStateChanger _stateChanger;
    private IPublisher<EnumGameState> statePublisher;
    private ISubscriber<EnumGameState> stateSubscriber;
    private IDisposable subscribingObject;
    
    private ObstacleGroup group;
    private GameObject cube;
    
    public GameInitializer(GameObject cube, FlappyCubeGameStateChanger stateChanger, IPublisher<EnumGameState> statePublisher, ObstacleGroup obsGroup, ISubscriber<EnumGameState> stateSubscriber)
    {
        this.cube = cube;
        this._stateChanger = stateChanger;
        this.statePublisher = statePublisher;
        this.group = obsGroup;
        this.stateSubscriber = stateSubscriber;
    }
    
    public void Initialize()
    {
        _stateChanger.ChangeState(EnumGameState.Idle);
        statePublisher.Publish(EnumGameState.Idle);
        subscribingObject = stateSubscriber.Subscribe(onGameStateChangedHandler);
    }

    private void onGameStateChangedHandler(EnumGameState obj)
    {
        Debug.Log("Game State Now : " + obj);
    }

    public void Tick()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (_stateChanger.GameState == EnumGameState.Idle || _stateChanger.GameState == EnumGameState.Dead))
        {
            cube.transform.position = Vector3.zero;
            group.ClearObstacle();
            _stateChanger.ChangeState(EnumGameState.Play);
            statePublisher.Publish(EnumGameState.Play);
        }
    }

    public void Dispose()
    {
        subscribingObject?.Dispose();
    }
}
