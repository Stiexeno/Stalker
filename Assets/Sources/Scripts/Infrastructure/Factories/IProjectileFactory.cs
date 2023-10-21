using UnityEngine;

namespace Roguelite
{
    public interface IProjectileFactory
    {
        GameEntity Create(string type, Vector2 position, Vector2 direciton, float speed);
    }
}
