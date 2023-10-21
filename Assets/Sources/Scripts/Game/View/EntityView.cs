using System;
using Entitas;
using Entitas.Unity;
using Framework;
using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace Roguelite
{
	public class EntityView : MonoBehaviour, IView
	{
		// Serialized fields

		[SF] private Roguelite.Enums.Team team;
        
		// Private fields

		private IEntityComponent[] behaviours = Array.Empty<IEntityComponent>();
		
		private IViewService viewService;
		private IIdentifierService identifierService;
		private ICollidingViewRegister collidingViewRegister;
		private Contexts contexts;

		// Properties
		
		public GameEntity Entity { get; private set; }
		public Contexts Context => contexts;

		//View

		[Inject]
		private void Construct(
			IViewService viewService, 
			IIdentifierService identifierService, 
			ICollidingViewRegister collidingViewRegister,
			Contexts contexts)
		{
			this.contexts = contexts;
			this.collidingViewRegister = collidingViewRegister;
			this.identifierService = identifierService;
			this.viewService = viewService;
			viewService.RegisterView(this);
		}
		
		public void Init(GameContext game, IEntity entity)
		{
			Entity = (GameEntity)entity;
			
			Entity.AddId(identifierService.Next(Identity.General));
			Entity.AddEntityBehaviour(this);
			Entity.AddTransform(transform);
			Entity.AddTeam(team);
			
			gameObject.Link(entity);
            
			RegisterViewBehaviours();
			RegisterViewListeners();
			RegisterCollisions();
			
			viewService.RegisterView(this);
		}
		
		public virtual void Process(in float deltaTime)
		{
			foreach (var behaviour in behaviours)
			{
				if (behaviour is IProcessable processable)
				{
					processable.Process(deltaTime);
				}
			}
		}

		public void Reuse()
		{
			foreach (var behaviour in behaviours)
			{
				if (behaviour is IReusable reusable)
				{
					reusable.Reuse();
				}
			}
		}

		private void RegisterViewBehaviours()
		{
			behaviours = GetComponentsInChildren<IEntityComponent>(true);
			
			foreach (var behaviour in behaviours)
			{
				behaviour.Initialize(this);
			}
		}

		private void RegisterViewListeners()
		{
			foreach (IEventListener listener in GetComponentsInChildren<IEventListener>(true))
				listener.RegisterListeners(Entity);
		}
		
		private void RegisterCollisions()
		{
			foreach (var colliderToRegister in GetComponentsInChildren<Collider2D>(includeInactive: true))
				collidingViewRegister.Register(colliderToRegister.GetInstanceID(), this);
		}

		private void UnregisterCollisions()
		{
			foreach (var childCollider in GetComponentsInChildren<Collider2D>())
				collidingViewRegister.Unregister(childCollider.GetInstanceID(), this);
		}
        
		protected void OnDestroy()
		{
			UnregisterCollisions();
			
			gameObject.Unlink();
			Destroy(gameObject);
		}
	}
}