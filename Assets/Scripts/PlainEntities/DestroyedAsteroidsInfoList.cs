using System.Collections.Generic;

namespace Assets.Scripts.PlainEntities
{
    //TODO: Convert in non-static class and use DI
    public static class DestroyedAsteroidsInfoList
    {
        private static Dictionary<string, DestroyedAsteroidInfo> destroyedAsteroidsInfoList;

        static DestroyedAsteroidsInfoList()
        {
            destroyedAsteroidsInfoList = new Dictionary<string, DestroyedAsteroidInfo>();
            destroyedAsteroidsInfoList.Add("asteroid01", new DestroyedAsteroidInfo() { Points = 1 }); 
            destroyedAsteroidsInfoList.Add("asteroid02", new DestroyedAsteroidInfo() { Points = 3 });
            destroyedAsteroidsInfoList.Add("asteroid03", new DestroyedAsteroidInfo() { Points = 5 });            
        }

        //TODO: Ensure that asteroidType exists, otherwise return non-value object
        public static DestroyedAsteroidInfo GetInfo(string asteroidType)
        {
            return destroyedAsteroidsInfoList[asteroidType];
        }
    }
}
