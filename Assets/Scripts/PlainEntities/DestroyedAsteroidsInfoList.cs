using System.Collections.Generic;

namespace Assets.Scripts.PlainEntities
{
    //TODO: Convert in non-static class and use DI
    public static class DestroyedEnemiesInfoList
    {
        private static Dictionary<string, DestroyedEnemyInfo> destroyedEnemiesInfoList;

        // Based on tags. But if we use the same tag for all enemies to simplify Explosion script... how we can do the same we are doing here?
        static DestroyedEnemiesInfoList()
        {
            destroyedEnemiesInfoList = new Dictionary<string, DestroyedEnemyInfo>();
            destroyedEnemiesInfoList.Add("asteroid01", new DestroyedEnemyInfo() { Points = 1 }); 
            destroyedEnemiesInfoList.Add("asteroid02", new DestroyedEnemyInfo() { Points = 3 });
            destroyedEnemiesInfoList.Add("asteroid03", new DestroyedEnemyInfo() { Points = 5 });
            destroyedEnemiesInfoList.Add("EnemyShip", new DestroyedEnemyInfo() { Points = 10 });
        }

        //TODO: Ensure that enemyTpe exists, otherwise return non-value object
        public static DestroyedEnemyInfo GetInfo(string enemyType)
        {
            return destroyedEnemiesInfoList[enemyType];
        }
    }
}
