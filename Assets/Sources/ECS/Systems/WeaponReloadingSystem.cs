using Entitas;

public class WeaponReloadingSystem : IExecuteSystem
{
	private readonly Contexts contexts;
	private readonly IGroup<GameEntity> weaponEntities;

	public WeaponReloadingSystem(Contexts contexts)
	{
		this.contexts = contexts;
		
		weaponEntities = contexts.game.GetGroup(GameMatcher
			.AllOf(
			GameMatcher.Weapon, 
			GameMatcher.Reloading,
			GameMatcher.ShootingCooldown,
			GameMatcher.Ammo,
			GameMatcher.MaxAmmo));
	}

	public void Execute()
	{
		foreach (var weaponEntity in weaponEntities.GetEntities())
		{
			if (weaponEntity.durationLeft.value <= 0)
			{
				var weaponOwner = contexts.game.GetEntityWithId(weaponEntity.ownerId.value);
				weaponOwner.isReloading = false;
				weaponEntity.isReloading = false;
				
				weaponOwner.isReloaded = true;
				weaponEntity.isReloaded = true;
				
				weaponEntity.ReplaceAmmo(weaponEntity.maxAmmo.value);
			}
		}
	}
}
