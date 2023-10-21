using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace Roguelite
{
    public class PlayerComponent : MonoBehaviour, IEntityComponent
    {
        // Serialized fields
	
    	// Private fields
	
    	// Properties
	
    	//PlayerComponent
	    
	    public void Initialize(EntityView entityView)
	    {
		    entityView.Entity.isPlayer = true;
	    }

	    public void Process(in float deltaTime)
	    {
	    }

	    public void Setup()
	    {
	    }
    }
}
