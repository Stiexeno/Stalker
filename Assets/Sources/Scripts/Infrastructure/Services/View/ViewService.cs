using System.Collections.Generic;
using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace Roguelite
{
    public class ViewService : MonoBehaviour, IViewService
    {
        // Serialized fields
	
    	// Private fields
	    
	    private List<IEntityView> views = new List<IEntityView>();
	
    	// Properties
	
    	//ViewController

	    private void Update()
	    {
		    foreach (var view in views)
		    {
			    view.Process(Time.deltaTime);
		    }
	    }

	    public void RegisterView(IEntityView value)
	    {
		    views.Add(value);
	    }
	    
	    public void RemoveView(IEntityView value)
	    {
		    views.Remove(value);
	    }
    }
}
