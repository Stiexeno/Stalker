using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace Roguelite
{
    public class Effect : MonoBehaviour
    {
        // Serialized fields
	
    	// Private fields

	    private string id;
	    private ParticleSystem system;

	    // Properties
	    
	    public string Id => id;
	    
	    private ParticleSystem System => system ? system : (system = GetComponent<ParticleSystem>());

	    //Effect

	    public void Take(string id, Vector3 position)
	    {
		    this.id = id;
		    transform.position = position;
		    gameObject.SetActive(true);
		    System.Play();
	    }
    }
}
