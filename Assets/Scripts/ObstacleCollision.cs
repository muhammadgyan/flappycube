using System;
using System.Collections;
using System.Collections.Generic;
using MessagePipe;
using UnityEngine;
using Zenject;

public class ObstacleCollision : IInitializable, IDisposable
{
    private Rigidbody cube;
    private FlappyCubeGameStateChanger stateChanger;
    private ISubscriber<string> stringSubscriber;
    private IDisposable subscriberDisposable;
    
    public ObstacleCollision(Rigidbody cube, FlappyCubeGameStateChanger stateChanger, MessagePipeManager messagePipeManager)
    {
        this.stateChanger = stateChanger;
        this.cube = cube;
        this.stringSubscriber = messagePipeManager.stringSubscriber;
    }
    
    void Collide()
    {
        if (stateChanger.GameState == EnumGameState.Play)
        {
            cube.velocity = Vector3.zero;
            stateChanger.ChangeState(EnumGameState.Dead);
        }
    }

    public void Initialize()
    {
        subscriberDisposable = stringSubscriber.Subscribe(onStringMessageReceivedHandler);
    }

    private void onStringMessageReceivedHandler(string obj)
    {
        if (obj == "Obstacle Collide")
        {
            Collide();
        }
    }

    public void Dispose()
    {
        subscriberDisposable?.Dispose();
    }
}
