using Animancer;
using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace Roguelite
{
    public class CharacterBehaviour2 : EntityBehaviour2
    {
        // Serialized fields
	
        [SF] protected int maxHealth = 5;
        
        [SF] protected LinearMixerTransition movementTransition;
        [SF] protected ClipTransition deathClip;
        
        [SF] protected SpriteRenderer characterSprite;
        [SF] protected new Rigidbody2D rigidbody2D;
        
    	// Private fields
	    
	    protected AnimancerComponent animancer;
	
    	// Properties
	
    	//CharacterBehaviour
	    
	    protected override void OnInit()
	    {
		    Entity.AddRigidbody(rigidbody2D);
		    Entity.AddHealth(maxHealth);
		    Entity.AddMaxHealth(maxHealth);
		    
		    animancer = GetComponentInChildren<AnimancerComponent>(true);
			animancer.Play(movementTransition);
	    }

	    protected override void OnProcess(in float deltaTime)
	    {
		    var direction = Entity.direction.value;
            
		    var rotationLerp = 0f;
		    if (direction.x > 0.1f || direction.x < -0.1f)
		    {
			    rotationLerp = Mathf.Lerp(2.5f, -2.5f, direction.x);
		    }
		   
		    characterSprite.transform.rotation = Quaternion.Euler(0, 0, rotationLerp);
            
		    if (direction.magnitude == 0f)
		    {
			    if (movementTransition.State.Parameter >= 4)
			    {
				    movementTransition.State.Parameter -= 4;   
			    }
			    return;			    
		    }
		    
		    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
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
