using Entitas;
using UnityEngine;

public class DurationSystem : IExecuteSystem
{
	private readonly Contexts contexts;
	private readonly IGroup<GameEntity> durationEntities;

	public DurationSystem(Contexts contexts)
	{
		this.contexts = contexts;

		durationEntities = contexts.game.GetGroup(GameMatcher
			.AllOf(GameMatcher.DurationLeft)
			.NoneOf(GameMatcher.DurationUp));
	}

	public void Execute()
	{
		foreach (GameEntity entity in durationEntities.GetEntities())
		{
			if (entity.durationLeft.value <= 0)
			{
				entity.isDurationUp = true;
				entity.RemoveDurationLeft();
				continue;
			}
			
			entity.ReplaceDurationLeft(entity.durationLeft.value - Time.deltaTime);
		}
	}
}
