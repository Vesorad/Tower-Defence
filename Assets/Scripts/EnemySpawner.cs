namespace Assets.Scripts.Enemies
{
    public class EnemySpawner
    {
        private readonly EnemyBasicFacade.Factory enemyBasicFactory;

        public EnemySpawner(EnemyBasicFacade.Factory enemyBasicFactory)
        {
            this.enemyBasicFactory = enemyBasicFactory;
        }

        public void SpawnEnemy()
        {
            enemyBasicFactory.Create();
        }
    }
}
