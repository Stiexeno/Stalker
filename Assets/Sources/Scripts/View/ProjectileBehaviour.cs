using Framework;
using Framework.Generated;
using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace Roguelite
{
	public class ProjectileBehaviour2 : EntityBehaviour2, IPooledListener
	{
		// Serialized fields
		
		[SF] private Rigidbody2D rigidbody2D;

		// Private fields
		
		private IEffectFactory effectFactory;

		// Properties

		//ProjectileView

		[Inject]
		private void Construct(IEffectFactory effectFactory)
		{
			this.effectFactory = effectFactory;
		}

		protected override void OnInit()
		{
			Entity.isProjectile = true;
			Entity.isPoolable = true;
			
			Entity.AddRigidbody(rigidbody2D);
			Entity.AddPooledListener(this);
		}

		protected override void OnSetup()
		{
			gameObject.SetActive(true);
			transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(Entity.direction.value.y, Entity.direction.value.x) * Mathf.Rad2Deg);	
		}
        
		public void OnPooled(GameEntity entity)
		{
			gameObject.SetActive(false);
		}

		//protected override void OnTriggerBy(Collider2D other)
		//{
		//	if (other.gameObject.layer == Constants.Layers.Obstacle || other.gameObject.layer == Constants.Layers.Character)
		//	{
		//		Entity.isSentToPool = true;
		//		Entity.isPooled = true;
		//		
		//		var contactPoint = other.ClosestPoint(transform.position);
        //        
		//		var effect = effectFactory.Take(Assets.Effects.Rifle_Hit_Blood, contactPoint);
		//		effect.transform.rotation = Quaternion.LookRotation(Entity.direction.value, Vector3.forward);
//
		//		return;
		//	}
		//}
	}
}