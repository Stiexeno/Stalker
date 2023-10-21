using System.Collections.Generic;
using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace Roguelite
{
    public class ViewService : MonoBehaviour, IViewService
    {
        // Serialized fields
	
    	// Private fields
	    
	    private List<IView> views = new List<IView>();
	
    	// Properties
	
    	//ViewController

	    private void Update()
	    {
		    foreach (var view in views)
		    {
			    view.Process(Time.deltaTime);
		    }
	    }

	    public void RegisterView(IView value)
	    {
		    views.Add(value);
	    }
	    
	    public void RemoveView(IView value)
	    {
		    views.Remove(value);
	    }
    }
}
