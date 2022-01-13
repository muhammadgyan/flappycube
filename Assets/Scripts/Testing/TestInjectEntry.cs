using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

public class TestInjectEntry : IStartable,ITickable
{
    readonly TestEntry _testEntry;
    public TestInjectEntry(TestEntry testEntry)
    {
        this._testEntry = testEntry;
    }

    public void Tick()
    {
        Debug.Log(_testEntry.GetTest());
    }

    public void Start()
    {
        Debug.Log("Start IStartable");
    }
}
