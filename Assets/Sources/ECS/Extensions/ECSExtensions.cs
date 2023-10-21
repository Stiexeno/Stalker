using Entitas;
using Framework.Utils;
using UnityEngine;

namespace Roguelite
{
    public static class ECSExtensions
    {
        public static void EquipWeapon(this GameEntity entity, GameEntity weapon)
        {
            weapon.ReplaceOwnerId(entity.id.value);
            entity.ReplaceCurrentWeapon(weapon);
            
            entity.isWeaponAdded = true;
        }

        public static void ReloadWeapon(this GameEntity owner, GameContext context)
        {
            var weapon = owner.currentWeapon.value;

            if (weapon.isReloading)
                return;
            
            var cooldownEntity = context.CreateEntity()
                .AddCooldown(owner, 1f)
                .With(x => x.isReloadingCooldown = true);
            
            weapon.ReplaceReloadingEntity(cooldownEntity);
            
            owner.isReloading = true;
            weapon.isReloading = true;
        }
        
        public static GameEntity AddCooldown(this GameEntity entity, GameEntity owner, float duration)
        {
            entity.AddDurationLeft(duration);
            entity.AddDuration(duration);
            entity.ReplaceOwnerId(owner.id.value);

            return entity;
        }

        public static GameEntity DealDamage(this GameContext gameContext, GameEntity toEntity, GameEntity attackerEntity, int damage)
        {
            GameEntity entity = gameContext.CreateEntity();

            entity.AddTargetId(toEntity.id.value);
            entity.AddDamageReceived(damage);
            toEntity.AddDamageReceivedFromAttacker(attackerEntity);

          //  entity.AddSourceId(attackerEntity.Id);
          //  toEntity.ReplaceAttacker(attackerEntity.hasOwnerId ? attackerEntity.OwnerId : attackerEntity.Id);

            return entity;
        }
        
        public static GameEntity GetEntity(this IGroup<GameEntity> group, GameContext context, int id)
        {
            GameEntity entity = context.GetEntityWithId(id);

            var existInGroups = group.ContainsEntity(entity);

            return existInGroups ? entity : null;
        }

        public static bool IsSameTeam(this GameEntity entity, GameEntity anotherEntity)
        {
            return entity.team.value == anotherEntity.team.value;
        }
        
        public static bool Matches(this Collider2D collider, LayerMask layerMask) =>
            ((1 << collider.gameObject.layer) & layerMask) != 0;
    }
}
