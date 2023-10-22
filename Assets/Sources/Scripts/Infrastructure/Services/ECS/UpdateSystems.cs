using Sources.ECS.Features;

namespace Roguelite
{
    public sealed class UpdateSystems : Feature
    {
        public UpdateSystems(Contexts contexts, ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<RegisterInputSystem>(contexts));
            Add(systemFactory.Create<UpdateInputSystem>(contexts));
            
            Add(systemFactory.Create<CleanupDestructedSystem>(contexts));
            
            Add(systemFactory.Create<WeaponAimingSystem>(contexts));
            Add(systemFactory.Create<PlayerInputSystem>(contexts));
            
            Add(systemFactory.Create<RangedWeaponSystem>(contexts));
            Add(systemFactory.Create<MeleeWeaponSystem>(contexts));
           // Add(systemFactory.Create<WeaponReloadingSystem>(contexts));
            Add(systemFactory.Create<WeaponShootingCooldownSystem>(contexts));
            Add(systemFactory.Create<WeaponReloadingCooldownSystem>(contexts));
            
            Add(systemFactory.Create<DurationSystem>(contexts));
            Add(systemFactory.Create<LifetimeSystem>(contexts));
            
            Add(systemFactory.Create<AgentMovementSystem>(contexts));
            
            Add(systemFactory.Create<BehaviourFeature>(contexts));
            
            Add(systemFactory.Create<DamageOnCollisionSystem>(contexts));
            Add(systemFactory.Create<SentProjectileToPoolSystem>(contexts));
            Add(systemFactory.Create<HealthSystem>(contexts));
            
            Add(systemFactory.Create<GameEventSystems>(contexts));
            Add(systemFactory.Create<GameCleanupSystems>(contexts));
            Add(systemFactory.Create<ResetCollidedSystem>(contexts));
        }
    }
}
