using Framework;
using Framework.Utils;
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
		   Async.Delay(1, () =>
		   {
			   characterFactory.CreateEnemy(transform.position);
		   });
	    }
    }
}
