using Entitas;
using Roguelite;
using UnityEngine;

public class DamageOnCollisionSystem : IExecuteSystem
{
	private readonly Contexts contexts;
	private readonly IGroup<GameEntity> damagedEntities;
	private readonly IGroup<GameEntity> collisions;

	public DamageOnCollisionSystem(Contexts contexts)
	{
		this.contexts = contexts;

		damagedEntities = contexts.game.GetGroup(GameMatcher
			.AllOf(GameMatcher.Collided, GameMatcher.Damage));
		
		collisions = contexts.game.GetGroup(GameMatcher
			.AllOf( GameMatcher.CollisionEvent, GameMatcher.OwnerId, GameMatcher.CollisionId));
	}

	public void Execute()
	{
		foreach (GameEntity collisionEventEntity in collisions.GetEntities())
		{
			GameEntity collidedDamageEntity = damagedEntities.GetEntity(contexts.game, collisionEventEntity.ownerId.value);
			GameEntity collisionEntity = contexts.game.GetEntityWithId(collisionEventEntity.collisionId.value);
			
			if (collidedDamageEntity == null || collisionEntity == null || collisionEntity.IsSameTeam(collidedDamageEntity))
				continue;

			contexts.game.DealDamage(collisionEntity, collidedDamageEntity, collidedDamageEntity.damage.value);
		}
	}
}
