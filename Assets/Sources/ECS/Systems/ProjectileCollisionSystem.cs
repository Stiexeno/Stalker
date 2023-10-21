using Entitas;
using Roguelite;

public class ProjectileCollisionSystem : IExecuteSystem
{
	private readonly Contexts contexts;
	private readonly IGroup<GameEntity> projectileEntities;

	public ProjectileCollisionSystem(Contexts contexts)
	{
		this.contexts = contexts;
		
		projectileEntities = contexts.game.GetGroup(GameMatcher
			.AllOf(
				GameMatcher.Projectile,
				GameMatcher.Collided,
				GameMatcher.Layer)
			.NoneOf(GameMatcher.SentToPool));
	}

	public void Execute()
	{
		foreach (var entity in projectileEntities.GetEntities())
		{
			if (entity.layer.value == Constants.Layers.Obstacle)
			{
				
			}
		}
	}
}
