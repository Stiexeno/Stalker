using Framework;
using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace Roguelite
{
    public class PlayerInputComponent : MonoBehaviour, IEntityInputComponent, IProcessable
    {
	    // Serialized fields
	
    	// Private fields
	    
	    private GameEntity entity;
	    private Contexts context;

	    // Properties
        
	    public Vector2 LookDirection { get; set; }
	    public Vector2 Velocity { get; set; }
	
    	//InputComponent
	    
	    public void Initialize(EntityView entityView)
	    {
		    entity = entityView.Entity;
		    context = entityView.Context;
	    }

	    public void Process(in float deltaTime)
	    {
		    LookDirection = context.input.aiming.value;
		    Velocity = context.input.movement.value;
	    }
    }
}
