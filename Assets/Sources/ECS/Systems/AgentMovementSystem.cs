using Entitas;
using UnityEngine;

public class AgentMovementSystem : IExecuteSystem
{
	private readonly Contexts contexts;
	private readonly IGroup<GameEntity> agentEntities;

	public AgentMovementSystem(Contexts contexts)
	{
		this.contexts = contexts;
		
		agentEntities = contexts.game.GetGroup(GameMatcher
			.AllOf(
				GameMatcher.Enemy, 
				GameMatcher.Transform,
				GameMatcher.Agent,
				GameMatcher.Direction));
	}

	public void Execute()
	{
		foreach (var agentEntity in agentEntities.GetEntities())
		{
			if (agentEntity.agent.value.isStopped == false)
			{
				var movementDirection = agentEntity.agent.value;
				agentEntity.ReplaceDirection(movementDirection.desiredVelocity.normalized);
			}
			else
			{
				agentEntity.ReplaceDirection(Vector2.zero);
			}
		}
	}
}
