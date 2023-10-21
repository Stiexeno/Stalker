using UnityEngine;

namespace Roguelite
{
    public interface IWeaponFactory
    {
        EntityView CreateRifle(Transform parent, GameEntity owner);
        EntityView CreateBullet();
    }
}
