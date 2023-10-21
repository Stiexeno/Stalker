using Entitas;
using UnityEngine;

public class ProjectileSystem : IExecuteSystem
{
	private readonly Contexts contexts;
	private readonly IGroup<GameEntity> projectiles;

	public ProjectileSystem(Contexts contexts)
	{
		this.contexts = contexts;
		
		//projectiles = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Projectile, GameMatcher.Position));
	}

	public void Execute()
	{
		//foreach (var projectile in projectiles)
		//{
		//	var transform = projectile.transform.value;
		//	projectile.transform.value.position = transform.forward * projectile.projectile.speed * Time.deltaTime;
		//}
	}
}
