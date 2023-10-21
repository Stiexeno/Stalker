using Entitas;
using UnityEngine;

public class LifetimeSystem : IExecuteSystem
{
	private readonly Contexts contexts;
	private IGroup<GameEntity> entities;

	public LifetimeSystem(Contexts contexts)
	{
		this.contexts = contexts;
		
		entities = contexts.game.GetGroup(GameMatcher
			.AllOf(GameMatcher.Lifetime, GameMatcher.Poolable)
			.NoneOf(GameMatcher.SentToPool));
	}

	public void Execute()
	{
		foreach (var entity in entities.GetEntities())
		{
			entity.lifetime.value -= Time.deltaTime;
			
			if (entity.lifetime.value <= 0)
			{
				entity.isSentToPool = true;
				entity.isPooled = true;
			}
		}
	}
}
