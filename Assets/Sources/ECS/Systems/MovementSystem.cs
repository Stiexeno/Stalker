using Entitas;
using UnityEngine;

public class MovementSystem : IExecuteSystem
{
	private readonly InputContext inputContext;
	private readonly IGroup<GameEntity> movementEntities;
	private readonly IGroup<GameEntity> inputEntities;

	public MovementSystem(Contexts contexts)
	{
		inputContext = contexts.input;
		inputEntities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.Direction));
		movementEntities = contexts.game.GetGroup(GameMatcher
			.AllOf(
				GameMatcher.MovementSpeed,
				GameMatcher.Direction,
				GameMatcher.Rigidbody)
			.NoneOf(GameMatcher.SentToPool));
	}
	
	public void Execute()
	{
		ProcessInputMovement();
		ProcessMovement();
	}

	private void ProcessInputMovement()
	{
		foreach (var inputEntity in inputEntities)
		{
			inputEntity.ReplaceDirection(inputContext.movement.value);
		}
	}
	
	private void ProcessMovement()
	{
		foreach (var entity in movementEntities)
		{
			var direction = entity.direction.value.normalized;
			var speed = entity.movementSpeed.value;

			var targetVelocity = direction * speed * Time.fixedDeltaTime;
			entity.rigidbody.value.velocity = targetVelocity;
		}
	}
}