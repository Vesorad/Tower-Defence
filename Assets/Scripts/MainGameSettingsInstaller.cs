using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "SettingsInstaller/Game Settings")]
    public class MainGameSettingsInstaller : ScriptableObjectInstaller<MainGameSettingsInstaller>
    {
        [field: SerializeField] public MonoInstallers.MainSceneInstaller.Settings MainSceneSettings{ private set; get; } = null;
        [field: SerializeField] public Roof.RoofController.Settings RoofSettings { private set; get; } = null;
        [field: SerializeField] public Tower.TowerController.Settings TowerSettings { private set; get; } = null;

        public override void InstallBindings()
        {
            Container.BindInstance(MainSceneSettings).IfNotBound();
            Container.BindInstance(RoofSettings).IfNotBound();
            Container.BindInstance(TowerSettings).IfNotBound();
        }
    }
}