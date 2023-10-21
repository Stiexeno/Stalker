using Framework;
using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace Roguelite
{
    public class Spawner : MonoBehaviour
    {
        // Serialized fields
	
    	// Private fields
	
    	// Properties
	
    	//Spawner

	    [Inject]
	    private void Construct(ICharacterFactory characterFactory)
	    {
		   characterFactory.CreateEnemy(transform.position);
	    }
    }
}
