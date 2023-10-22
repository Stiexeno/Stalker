using DG.Tweening;
using Framework;
using Framework.Generated;
using Roguelite;
using UnityEngine;
using SF = UnityEngine.SerializeField;

[RequireComponent(typeof(HealthComponent))]
public class FlashOnDamageComponent : MonoBehaviour, IEntityComponent, IDamageReceivedFromAttackerListener
{
    // Serialized fields
    
    [SF] private new Renderer renderer;
	
	// Private fields
	
	private IEffectFactory effectFactory;
	
	private static readonly int flashProperty = Shader.PropertyToID("_FlashAmount");
	
	// Properties
	
	//DamageReceivedComponent
	
	[Inject]
	private void Construct(IEffectFactory effectFactory)
	{
		this.effectFactory = effectFactory;
	}
	
	public void Initialize(EntityView entityView)
	{
		entityView.Entity.AddDamageReceivedFromAttackerListener(this);
	}

	public void OnDamageReceivedFromAttacker(GameEntity entity, GameEntity value)
	{
		var materialBlock = new MaterialPropertyBlock();
		materialBlock.SetFloat(flashProperty, 1);
		DOVirtual.Float(0.9f, 0, 0.08f, val =>
			{
				renderer.GetPropertyBlock(materialBlock);
				materialBlock.SetFloat(flashProperty, val);
				renderer.SetPropertyBlock(materialBlock);
			})
			.SetEase(Ease.OutSine).SetUpdate(true);
            
		var effect = effectFactory.Take(Assets.Effects.Rifle_Hit_Blood, transform.position);
		effect.transform.rotation = Quaternion.LookRotation(value.direction.value, Vector3.forward);
	}
}
