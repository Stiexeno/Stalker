using Entitas;

public class CleanupDestructedSystem : ICleanupSystem
{
	private readonly IGroup<GameEntity> _destructed;

	public CleanupDestructedSystem(Contexts contexts) => 
		_destructed = contexts.game.GetGroup(GameMatcher.Destructed);

	public void Cleanup()
	{
		foreach (var destructedEntity in _destructed.GetEntities())
		{
			destructedEntity.Destroy();
		}
	}
}