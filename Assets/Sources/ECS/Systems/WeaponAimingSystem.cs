using Entitas;

public class WeaponAimingSystem : IExecuteSystem
{
	private readonly Contexts contexts;
	private IGroup<GameEntity> weaponEntities;

	public WeaponAimingSystem(Contexts contexts)
	{
		this.contexts = contexts;

		weaponEntities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Weapon, GameMatcher.Direction));
	}

	public void Execute()
	{
		foreach (var weaponEntity in weaponEntities)
		{
			weaponEntity.ReplaceDirection(contexts.input.aiming.value);
		}
	}
}
