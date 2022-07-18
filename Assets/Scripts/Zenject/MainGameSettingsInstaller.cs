using Assets.Scripts.Managers;
using Assets.Scripts.Units.Enemy;
using Assets.Scripts.Units.Player;
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
        [field: SerializeField] public EnemySpawner.Settings EnemySpawnerSettings { private set; get; } = null;
        [field: SerializeField] public EnemyUnits EnemyUnitsSettings { private set; get; } = null;
        [field: SerializeField] public PlayerUnits PlayerUnitsSeetings { private set; get; } = null;


        public override void InstallBindings()
        {
            Container.BindInstance(FactorySettings).IfNotBound();
            Container.BindInstance(RoofSettings).IfNotBound();
            Container.BindInstance(TowerBuidlingSettings).IfNotBound();

            Container.BindInstance(EnemySpawnerSettings).IfNotBound();
            Container.BindInstance(EnemyUnitsSettings.EnemyBasic).IfNotBound();
            Container.BindInstance(EnemyUnitsSettings.EnemyShield).IfNotBound();
            Container.BindInstance(PlayerUnitsSeetings.PlayerBasic).IfNotBound();
        }

        [System.Serializable]
        public class EnemyUnits
        {
            [field: SerializeField] public EnemyUnitBasicInstaller.Settings EnemyBasic { private set; get; } = null;
            [field: SerializeField] public EnemyUnitShieldInstaller.Settings EnemyShield { private set; get; } = null;
        }

        [System.Serializable]
        public class PlayerUnits
        {
            [field: SerializeField] public PlayerUnitBasicInstaller.Settings PlayerBasic { private set; get; } = null;
        }
    }
}