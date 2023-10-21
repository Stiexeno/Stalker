using Entitas;

public class WeaponShootingCooldownSystem : IExecuteSystem
{
	private readonly GameContext gameContext;
	private readonly IGroup<GameEntity> weaponEntities;

	public WeaponShootingCooldownSystem(Contexts contexts)
	{
		this.gameContext = contexts.game;
		weaponEntities = contexts.game.GetGroup(GameMatcher
			.AllOf(GameMatcher.OwnerId, GameMatcher.DurationUp, GameMatcher.ShootingCooldown));
	}

	public void Execute()
	{
		foreach (GameEntity entity in weaponEntities.GetEntities())
		{
			var owner = gameContext.GetEntityWithId(entity.ownerId.value);

			if (owner != null)
			{
				owner.isShootingCooldown = false;
				entity.isDestructed = true;
			}
		}
	}
}
