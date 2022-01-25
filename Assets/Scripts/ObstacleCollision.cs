using System;
using System.Collections;
using System.Collections.Generic;
using MessagePipe;
using UnityEngine;
using VContainer.Unity;

public class ObstacleCollision : IInitializable, IDisposable
{
    private Rigidbody cube;
    private FlappyCubeGameStateChanger stateChanger;
    private ISubscriber<string> stringSubscriber;
    private IDisposable subscriberDisposable;
    private IPublisher<EnumGameState> statePublisher;
    
    public ObstacleCollision(Rigidbody cube, FlappyCubeGameStateChanger stateChanger, ISubscriber<string> subscriber, IPublisher<EnumGameState> statePublisher)
    {
        this.stateChanger = stateChanger;
        this.cube = cube;
        this.stringSubscriber = subscriber;
        this.statePublisher = statePublisher;
    }
    
    void Collide()
    {
        if (stateChanger.GameState == EnumGameState.Play)
        {
            cube.velocity = Vector3.zero;
            stateChanger.ChangeState(EnumGameState.Dead);
            statePublisher.Publish(EnumGameState.Dead);
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
