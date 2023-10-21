using Framework;
using Framework.Core;
using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace Roguelite
{
    public class CameraTarget : MonoBehaviour
    {
	    // Serialized fields
	    
    	// Private fields
	
    	// Properties
	
    	//CameraTarget

	    [Inject]
	    private void Construct(ICamera camera)
	    {
		    camera.SetTarget(transform);
	    }
    }
}
