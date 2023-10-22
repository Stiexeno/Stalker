using Animancer;
using Framework;
using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace Roguelite
{
    public class MovementAnimationComponent : MonoBehaviour, IEntityComponent, IProcessable
    {
        // Serialized fields
        
        [SF] protected LinearMixerTransition movementTransition;
	
    	// Private fields

	    private AnimancerComponent animancer;
	    
	    private IEntityInputComponent input;
	    private GameEntity entity;
	    
	    // Constants
	    
	    private const float BACK_PARAMETER = 0;
	    private const float RIGHT_PARAMETER = 1;
	    private const float FRONT_PARAMETER = 2;
	    private const float LEFT_PARAMETER = 3;

	    // Properties
	
    	//AnimationComponent
	    
	    public void Initialize(EntityView entityView)
	    {
		    entity = entityView.Entity;
		    
		    animancer = GetComponentInChildren<AnimancerComponent>(true);
		    input = GetComponent<IEntityInputComponent>();
		    animancer.Play(movementTransition);
	    }

	    public void Process(in float deltaTime)
	    {
		    if (entity.isDead == true)
			    return;
		    
		    var aimingDirection = input.LookDirection;
		    var velocity = input.Velocity;

		    if (velocity.magnitude == 0f && aimingDirection.magnitude == 0f)
		    {
			    if (movementTransition.State.Parameter >= 4)
			    {
				    movementTransition.State.Parameter -= 4;   
			    }
			    return;
		    }
            
		    float angle = Mathf.Atan2(aimingDirection.y, aimingDirection.x) * Mathf.Rad2Deg;
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
		    
		    parameter += Mathf.RoundToInt(velocity.magnitude) * 4f;
            
		    movementTransition.State.Parameter = parameter;
	    }
    }
}
