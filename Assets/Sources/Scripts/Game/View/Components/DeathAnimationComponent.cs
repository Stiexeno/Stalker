using Animancer;
using Roguelite;
using UnityEngine;
using SF = UnityEngine.SerializeField;

public class DeathAnimationComponent : MonoBehaviour, IEntityComponent, IDeadListener
{
    // Serialized fields
    
    [SF] protected LinearMixerTransition movementTransition;
	
	// Private fields
	
	private IEntityInputComponent input;
	
	private AnimancerComponent animancer;
	
	private const float BACK_PARAMETER = 0;
	private const float RIGHT_PARAMETER = 1;
	private const float FRONT_PARAMETER = 2;
	private const float LEFT_PARAMETER = 3;
	
	// Properties
	
	//DeathAnimationComponent
	
	public void Initialize(EntityView entityView)
	{
		var entity = entityView.Entity;
		entity.AddDeadListener(this);
		
		animancer = GetComponentInChildren<AnimancerComponent>(true);
		input = GetComponent<IEntityInputComponent>();
	}

	public void OnDead(GameEntity entity)
	{
		var direction = input.Velocity;
		
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		
		var rotationAngle = rotation.eulerAngles.z;
            
		var parameter = 0f;
            
		if (rotationAngle >= 315 || rotationAngle <= 45)
		{
			parameter = RIGHT_PARAMETER;
		}
		else if (rotationAngle >= 45 && rotationAngle <= 135)
		{
			parameter = BACK_PARAMETER;
		}
		else if (rotationAngle >= 225 && rotationAngle <= 315)
		{
			parameter = FRONT_PARAMETER;
		}
		else if (rotationAngle >= 135 && rotationAngle <= 225)
		{
			parameter = LEFT_PARAMETER;
		}
		
		animancer.Play(movementTransition);
		movementTransition.State.Parameter = parameter;
	}
}
