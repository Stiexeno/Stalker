using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace Roguelite
{
    public class MovementComponent : MonoBehaviour, IEntityComponent
    {
        // Serialized fields

        [SF] private float speed = 100f;
	
    	// Private fields

	    private Rigidbody2D rb;
	
    	// Properties
	
    	//MovementComponent
	    
	    public void Initialize(EntityView entityView)
	    {
		    rb = entityView.GetComponent<Rigidbody2D>();
		    
		    entityView.Entity.AddMovementSpeed(speed);
		    entityView.Entity.AddDirection(Vector2.zero);
		    entityView.Entity.AddRigidbody(rb);
	    }
    }
}
