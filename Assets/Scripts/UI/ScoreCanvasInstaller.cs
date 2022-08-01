using MySignals;
using UnityEngine;
using Zenject;

namespace UI
{
    public class ScoreCanvasInstaller : MonoInstaller
    {
        [SerializeField] private SettingsPreFab settingsPreFab = null;

        public override void InstallBindings()
        {
            Container.Bind<ScoreCanvasController>().AsSingle().WithArguments(settingsPreFab.Canvas);

            BindSignals();
        }

        private void BindSignals()
        {
            Container.BindSignal<EndGameSignal>().ToMethod<ScoreCanvasController>((x, s) => x.ShowScoreCanvas()).FromResolve();
        }

        [System.Serializable]
        public class SettingsPreFab
        {
            [field: SerializeField] public GameObject Canvas { private set; get; } = null;
        }

    }
}