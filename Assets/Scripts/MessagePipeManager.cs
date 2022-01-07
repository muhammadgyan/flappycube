using System.Collections;
using System.Collections.Generic;
using MessagePipe;
using UnityEngine;
using Zenject;

public class MessagePipeManager
{
    public IPublisher<string> stringPublisher { get; private set; }
    public ISubscriber<string> stringSubscriber { get; private set; }
    
    public MessagePipeManager(DiContainer container)
    {
        var options = container.BindMessagePipe();
        container.BindMessageBroker<string>(options);
        GlobalMessagePipe.SetProvider(container.AsServiceProvider());
        
        stringPublisher = GlobalMessagePipe.GetPublisher<string>();
        stringSubscriber = GlobalMessagePipe.GetSubscriber<string>();
    }

}

