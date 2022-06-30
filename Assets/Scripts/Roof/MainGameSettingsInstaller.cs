using UnityEngine;
using Zenject;

namespace Assets.Scripts.Roof
{
    [CreateAssetMenu(menuName = "SettingsInstaller/Game Settings")]
    public class MainGameSettingsInstaller : ScriptableObjectInstaller<MainGameSettingsInstaller>
    {
        [field: SerializeField] public RoofController.Settings RoofSettings { private set; get; } = null;

        public override void InstallBindings()
        {
            Container.BindInstance(RoofSettings).IfNotBound();
        }
    }
}
