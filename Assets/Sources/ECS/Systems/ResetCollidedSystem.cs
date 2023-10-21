using Entitas;

namespace Roguelite
{
	public class ResetCollidedSystem : ICleanupSystem
	{
		private readonly IGroup<GameEntity> _collided;

		public ResetCollidedSystem(Contexts contexts)
		{
			_collided = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Collided));
		}

		public void Cleanup()
		{
			foreach (GameEntity entity in _collided.GetEntities())
			{
				entity.isCollided = false;

				if (entity.hasCollisionId) 
					entity.RemoveCollisionId();

				if (entity.hasCollidedWith)
					entity.collidedWith.value.Clear();
			}
		}
	}
}