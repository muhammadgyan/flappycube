using System;
using System.Collections;
using System.Collections.Generic;
using MessagePipe;
using UnityEngine;
using VContainer;

public class View_InstructionPanel : MonoBehaviour
{
    private ISubscriber<EnumGameState> subscriber;
    private IDisposable subscriberDisposable;

    [SerializeField]
    private GameObject instructionGO;
    
    [Inject]
    public void Init(ISubscriber<EnumGameState> subscriber)
    {
        this.subscriber = subscriber;
        subscriberDisposable = subscriber.Subscribe(onGameStateChanged);
    }

    private void onGameStateChanged(EnumGameState obj)
    {
        Debug.Log(obj);
        instructionGO.SetActive(obj == EnumGameState.Idle);
    }

    private void OnDisable()
    {
        subscriberDisposable?.Dispose();
    }
}
