using Entitas;
using Framework.Bot;
using Roguelite;
using UnityEngine;

public class WanderSystem : IExecuteSystem
{
	private readonly IGroup<GameEntity> wanderNodeGroup;
	private readonly IGroup<GameEntity> agentGroup;
	private readonly GameContext contextGame;

	public WanderSystem(Contexts contexts)
	{
		contextGame = contexts.game;

		wanderNodeGroup = contextGame.GetGroup(GameMatcher
			.AllOf(GameMatcher.Wander, GameMatcher.TargetPosition, GameMatcher.Timelapsed, GameMatcher.OwnerId));

		agentGroup = contextGame.GetGroup(GameMatcher
			.AllOf(GameMatcher.Agent, GameMatcher.Id));
	}

	public void Execute()
	{
		foreach (GameEntity nodeEntity in wanderNodeGroup.GetEntities())
		{
			GameEntity ownerEntity = agentGroup.GetEntity(contextGame, nodeEntity.ownerId.value);

			if (ownerEntity == null)
				continue;

			nodeEntity.ReplaceTimelapsed(nodeEntity.timelapsed.value + Time.deltaTime);

			if (IsReachedTargetPosition(ownerEntity, nodeEntity.targetPosition.value) || nodeEntity.timelapsed.value > 5)
			{
				ownerEntity.agent.value.isStopped = true;
				nodeEntity.isWander = false;
				nodeEntity.ReplaceNodeStatus(BTStatus.Success);

				continue;
			}

			nodeEntity.ReplaceNodeStatus(BTStatus.Running);
		}
	}

	private bool IsReachedTargetPosition(GameEntity entity, Vector3 targetPosition) =>
		Vector2.Distance(entity.transform.value.position, targetPosition) < 1;
}