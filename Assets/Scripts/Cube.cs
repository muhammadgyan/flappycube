using System;
using System.Collections;
using System.Collections.Generic;
using MessagePipe;
using UnityEngine;
using VContainer;

public class Cube : MonoBehaviour
{
    private IPublisher<string> stringPublisher;
    
    [Inject]
    public void Init(IPublisher<string> messagePipeManager)
    {
        this.stringPublisher = messagePipeManager;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
            stringPublisher.Publish("Obstacle Collide");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Point"))
            stringPublisher.Publish("Point Scored");
    }
}
