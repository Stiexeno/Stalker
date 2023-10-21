using System.Collections.Generic;
using Framework;
using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace Roguelite
{
	public class TriggerOnEnter : MonoBehaviour, IEntityComponent
	{
		// Serialized fields

		[SF] private LayerMask layerMask;

		// Private fields
        
		private Contexts contexts;
		private GameEntity entity;
		
		private ICollidingViewRegister collidingViewRegister;

		// Properties

		//TriggerOnEnter

		[Inject]
		private void Construct(ICollidingViewRegister collidingViewRegister, Contexts contexts)
		{
			this.contexts = contexts;
			this.collidingViewRegister = collidingViewRegister;
		}
        
		public void Initialize(EntityView entityView)
		{
			entity = entityView.Entity;
		}

		public void Setup()
		{
		}

		public void Process(in float deltaTime)
		{
		}
		
		private void OnTriggerEnter2D(Collider2D other)
		{
			TriggerBy(other);
		}
		
		private void TriggerBy(Collider2D other)
		{
			var otherInstanceID = other.GetInstanceID();
            
			if (other.Matches(layerMask))
			{
				var controller = collidingViewRegister.Take(otherInstanceID);

				if (controller != null && !IsCollidedWith(controller.Entity))
				{
					GameEntity enteredEntity = controller.Entity;

					contexts.game.MarkCollided(entity, by: enteredEntity.id.value);
					contexts.game.MarkCollided(enteredEntity, by: entity.id.value);
				}
				else
				{
					contexts.game.MarkCollided(entity);
				}
			}
		}
		
		private bool IsCollidedWith(GameEntity controllerEntity) => entity.hasCollidedWith && entity.collidedWith.value.Contains(controllerEntity.id.value);
	}
	
	public static class CleanCodeExtensions
	{
		public static void MarkCollided(this GameContext context, GameEntity entity, int by)
		{
			entity.isCollided = true;

			if (!entity.hasCollidedWith) 
				entity.AddCollidedWith(new HashSet<int>());

			entity.collidedWith.value.Add(by);
            
			GameEntity eventEntity = context.CreateEntity();
			eventEntity.isCollisionEvent = true;
			eventEntity.AddOwnerId(entity.id.value);
			eventEntity.ReplaceCollisionId(by);
		}
        
		public static void MarkCollided(this GameContext context, GameEntity entity)
		{
			entity.isCollided = true;
            
			GameEntity eventEntity = context.CreateEntity();
			eventEntity.isCollisionEvent = true;
			eventEntity.AddOwnerId(entity.id.value);
		}
	}
}