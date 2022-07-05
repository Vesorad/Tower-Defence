using Assets.Scripts.Enemies;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Zenject
{
    [CreateAssetMenu(menuName = "SettingsInstaller/Game Settings")]
    public class MainGameSettingsInstaller : ScriptableObjectInstaller<MainGameSettingsInstaller>
    {
        [field: SerializeField] public GameFactores.Settings FactorySettings { private set; get; } = null;
        [field: SerializeField] public Roof.RoofController.Settings RoofSettings { private set; get; } = null;
        [field: SerializeField] public Tower.TowerBuidlingController.Settings TowerBuidlingSettings { private set; get; } = null;
        [field: SerializeField] public Enemies EnemiesSettings { private set; get; } = null;


        public override void InstallBindings()
        {
            Container.BindInstance(FactorySettings).IfNotBound();
            Container.BindInstance(RoofSettings).IfNotBound();
            Container.BindInstance(TowerBuidlingSettings).IfNotBound();

            Container.BindInstance(EnemiesSettings.EnemyBasic).IfNotBound();
        }

        [System.Serializable]
        public class Enemies
        {
            [field: SerializeField] public Enemy.Settings EnemyBasic { private set; get; } = null;
        }
    }
}