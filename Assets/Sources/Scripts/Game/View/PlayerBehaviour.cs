using Framework;
using Framework.Core;
using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace Roguelite
{
    public class PlayerBehaviour2 : CharacterBehaviour2
    {
	    // Serialized fields
	
    	// Private fields
	    
	    private new ICamera camera;
	
    	// Properties
	
    	//PlayerBehaviour

	    [Inject]
	    private void Construct(ICamera camera)
	    {
		    this.camera = camera;
	    }
	    
	    protected override void OnInit()
	    {
		    base.OnInit();
		    
		    Entity.isPlayer = true;
		    Entity.AddMovementSpeed(100f);
		    Entity.AddDirection(Vector2.zero);
		    
		    camera.SetTarget(transform);
	    }

	    protected override void OnProcess(in float deltaTime)
	    {
		    var aimingDirection = Context.input.aiming.value;
            
		    //characterSprite.flipX = aimingDirection.x < 0;
		    
		    var direction = Entity.direction.value;
		    //movementTransition.State.Parameter = Mathf.RoundToInt(direction.magnitude);

		    var rotationLerp = 0f;
		    if (direction.x > 0.1f || direction.x < -0.1f)
		    {
			    rotationLerp = Mathf.Lerp(2.5f, -2.5f, direction.x);
		    }
		   
		    characterSprite.transform.rotation = Quaternion.Euler(0, 0, rotationLerp);
            
		    float angle = Mathf.Atan2(aimingDirection.y, aimingDirection.x) * Mathf.Rad2Deg;
		    Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		        
		    var rotationAngle = rotation.eulerAngles.z;
            
		    const float backParameter = 0;
		    const float rightParameter = 1;
		    const float frontParameter = 2;
		    const float leftParameter = 3;
		    
		    var parameter = 0f;
            
		    if (rotationAngle >= 315 || rotationAngle <= 45)
		    {
			    parameter = rightParameter;
		    }
		    else if (rotationAngle >= 45 && rotationAngle <= 135)
		    {
			    parameter = backParameter;
		    }
		    else if (rotationAngle >= 225 && rotationAngle <= 315)
		    {
			    parameter = frontParameter;
		    }
		    else if (rotationAngle >= 135 && rotationAngle <= 225)
		    {
			    parameter = leftParameter;
		    }
		    
		    parameter += Mathf.RoundToInt(direction.magnitude) * 4f;
            
		    movementTransition.State.Parameter = parameter;
	    }
    }
}
