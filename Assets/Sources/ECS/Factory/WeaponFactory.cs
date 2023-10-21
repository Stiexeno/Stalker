using Framework.Core;
using Framework.Generated;
using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace Roguelite
{
    public class WeaponFactory : AbstractEntityFactory, IWeaponFactory
    {
        private EntityView riflePrefab;
        private EntityView bulletPrefab;
        
        public WeaponFactory(Contexts contexts, IAssets assets) : base(contexts, assets)
        {
            riflePrefab = assets.GetPrefab<EntityView>(Assets.Weapons.Weapon_Rifle);
            bulletPrefab = assets.GetPrefab<EntityView>(Assets.Projectiles.Projectile);
        }

        public EntityView CreateRifle(Transform parent, GameEntity owner)
        {
            var weapon = CreateView(riflePrefab.gameObject, riflePrefab.gameObject.transform.localPosition, parent);
            
            owner?.EquipWeapon(weapon.Entity);
            return weapon;
        }

        public EntityView CreateBullet()
        {
            var bullet = CreateView(bulletPrefab.gameObject, Vector3.zero);
            bullet.Entity.AddMovementSpeed(1500f);
            bullet.Entity.AddDamage(1);

            return bullet;
        }
    }
}
