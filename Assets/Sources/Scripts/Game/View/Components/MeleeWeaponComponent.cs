using Framework;
using Roguelite;
using UnityEngine;
using SF = UnityEngine.SerializeField;

public class MeleeWeaponComponent : MonoBehaviour, IEntityComponent, IProcessable
{
    // Serialized fields
	
	// Private fields
	
	private IEntityInputComponent inputComponent;
	
	// Properties
	
	//MeleeWeaponComponent
	
	public void Initialize(EntityView entityView)
	{
		var entity = entityView.Entity;
		    
		entity.isWeapon = true;
		entity.AddDirection(Vector3.zero);
		
		inputComponent = GetComponentInParent<IEntityInputComponent>();
	}

	public void Process(in float deltaTime)
	{
		var aimingDirection = inputComponent.LookDirection;
			
		float angle = Mathf.Atan2(aimingDirection.y, aimingDirection.x) * Mathf.Rad2Deg;
		Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 50 * deltaTime);
	}
}
