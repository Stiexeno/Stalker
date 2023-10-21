using Entitas;
using Framework.Utils;
using Roguelite;

public class SentProjectileToPoolSystem : IExecuteSystem
{
	private readonly Contexts contexts;
	private readonly IGroup<GameEntity> collidedBullets;
	private readonly IGroup<GameEntity> collisions;

	public SentProjectileToPoolSystem(Contexts contexts)
	{
		this.contexts = contexts;
		
		collidedBullets = contexts.game.GetGroup(GameMatcher
			.AllOf(GameMatcher.Projectile, GameMatcher.Collided)
			.NoneOf(GameMatcher.Pooled));
            
		collisions = contexts.game.GetGroup(GameMatcher
			.AllOf( GameMatcher.CollisionEvent, GameMatcher.OwnerId, GameMatcher.CollisionId));
	}

	public void Execute()
	{
		foreach (GameEntity collisionEventEntity in collisions)
		{
			GameEntity collidedBulletEntity = collidedBullets.GetEntity(contexts.game, collisionEventEntity.ownerId.value);
			GameEntity collisionEntity = contexts.game.GetEntityWithId(collisionEventEntity.collisionId.value);
                
			if (collidedBulletEntity == null || collisionEntity == null || collisionEntity.isDead || collisionEntity.IsSameTeam(collidedBulletEntity))
				continue;
            
			collidedBulletEntity.isSentToPool = true;
			collidedBulletEntity.isPooled = true;
				
		}
	}
}