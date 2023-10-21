using UnityEngine;

namespace Roguelite
{
    public class ProjectileFactory : IProjectileFactory
    {
        public GameEntity Create(string type, Vector2 position, Vector2 direciton, float speed)
        {
            //var entity = Contexts.sharedInstance.game.CreateEntity();
            //entity.AddAsset(type, position, null, true);
            //entity.AddProjectile(direciton, speed, 0);
            //entity.AddMovement(direciton, speed);

            return null;
        }
    }
}
