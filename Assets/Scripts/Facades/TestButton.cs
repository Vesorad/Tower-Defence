using Assets.Scripts.Signals;
using UnityEngine;
using Zenject;

public class TestButton : MonoBehaviour
{
    private SignalBus signalBus;

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        this.signalBus = signalBus;
    }

    public void TriggerButton()
    {
        signalBus.Fire<BuildTowerSignal>();
    }
}