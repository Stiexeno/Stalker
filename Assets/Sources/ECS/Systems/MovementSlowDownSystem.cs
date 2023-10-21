using Entitas;
using UnityEngine;

public class MovementSlowDownSystem : IExecuteSystem
{
	private readonly IGroup<GameEntity> movementEntities;

	public MovementSlowDownSystem(Contexts contexts)
	{
		movementEntities = contexts.game.GetGroup(GameMatcher
			.AllOf(
				GameMatcher.MovementSpeed,
				GameMatcher.Direction,
				GameMatcher.Rigidbody)
			.NoneOf(GameMatcher.SentToPool, GameMatcher.Projectile));
	}
	
	public void Execute()
	{
		ProcessMovement();
	}
	
	private void ProcessMovement()
	{
		foreach (var entity in movementEntities)
		{
			var rigidbody = entity.rigidbody.value;
			//var movementSlowDownModifier = entity.movementSlowModifier;
			var movementDirection = entity.direction.value;

			if (movementDirection == Vector2.zero)
			{
				rigidbody.velocity += -rigidbody.velocity * 15f * Time.fixedDeltaTime;
			}
		}
	}
}