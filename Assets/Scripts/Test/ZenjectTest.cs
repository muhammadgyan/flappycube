using System.ComponentModel;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class ZenjectTest : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<string>().FromInstance("Test Zenject");
            Container.Bind<TestString>().AsSingle().NonLazy();
        }
    }

    public class TestString
    {
        public TestString(string msg)
        {
            Debug.Log(msg);
        }
    }
}