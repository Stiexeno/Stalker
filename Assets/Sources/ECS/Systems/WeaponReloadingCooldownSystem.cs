using Entitas;
using UnityEngine;
using SF = UnityEngine.SerializeField;

public class WeaponReloadingCooldownSystem : IExecuteSystem
{
	private readonly GameContext gameContext;
	private readonly IGroup<GameEntity> weaponEntities;

	public WeaponReloadingCooldownSystem(Contexts contexts)
	{
		this.gameContext = contexts.game;
		weaponEntities = contexts.game.GetGroup(GameMatcher
			.AllOf(GameMatcher.OwnerId, GameMatcher.DurationUp, GameMatcher.ReloadingCooldown));
	}

	public void Execute()
	{
		foreach (GameEntity entity in weaponEntities.GetEntities())
		{
			var owner = gameContext.GetEntityWithId(entity.ownerId.value);
			var weapon = owner.currentWeapon.value;

			if (weapon != null)
			{
				weapon.isReloadingCooldown = false;
				entity.isDestructed = true;
                
				owner.isReloading = false;
				weapon.isReloading = false;
				
				owner.isReloaded = true;
				weapon.isReloaded = true;
				
				weapon.ReplaceAmmo(weapon.maxAmmo.value);
			}
		}
	}
}
