using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace Roguelite
{
    public class ProjectileComponent : MonoBehaviour, IEntityComponent, IPooledListener
    {
        // Serialized fields
	
    	// Private fields

	    private Rigidbody2D rb;
	    private GameEntity entity;

	    // Properties
	
    	//ProjectileComponent
	    
	    public void Initialize(EntityView entityView)
	    {
		    rb = GetComponent<Rigidbody2D>();
		    
		    entity = entityView.Entity;
		    
		    entity.isProjectile = true;
		    entity.isPoolable = true;
			
		    entity.AddRigidbody(rb);
		    entity.AddPooledListener(this);
	    }

	    public void Setup()
	    {
		    gameObject.SetActive(true);
		    transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(entity.direction.value.y, entity.direction.value.x) * Mathf.Rad2Deg);	
	    }

	    public void Process(in float deltaTime)
	    {
	    }

	    public void OnPooled(GameEntity entity)
	    {
		    gameObject.SetActive(false);
	    }
    }
}
