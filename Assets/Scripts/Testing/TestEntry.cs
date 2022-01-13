using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

public class TestEntry : IInitializable
{
    private string test = "aaaa";
    public TestEntry()
    {
        test = "ini test entry";
    }

    public string GetTest()
    {
        return test;
    }

    public void Initialize()
    {
        Debug.Log("Initialize Test Entry");
    }
}
