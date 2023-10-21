using System;
using Framework;
using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace Roguelite
{
    public class Runner : MonoBehaviour
    {
	    // Serialized fields
	
    	// Private fields
	    
	    private ISystemFactory systemFactory;
	    private IInstantiator instantiator;

	    // Properties
	
    	//GameManager

	    [Inject]
	    private void Construct(
		    ISystemFactory systemFactory,
		    IInstantiator instantiator)
	    {
		    this.instantiator = instantiator;
		    this.systemFactory = systemFactory;
		    
		    Boot();
	    }
	    
	    private void Boot()
	    {
		  //  var contexts = Contexts.sharedInstance;
//
		  // var updateSystems = systemFactory.Create<UpdateSystems>(contexts, systemFactory);
		  // var fixedUpdateSystems = systemFactory.Create<FixedUpdateSystems>(contexts, systemFactory);
//
		  // var facade = systemFactory.Create<Facade>(contexts, updateSystems, fixedUpdateSystems);
		  // gameState = instantiator.Instantiate<GameState>(facade, updateSystems, fixedUpdateSystems);
          //  
		  // gameState.Enter();
	    }
	    
	    private void Update()
	    {
		   // gameState.Process(Time.deltaTime);
	    }

	    public void FixedUpdate()
	    {
		   // gameState.FixedProcess(Time.fixedDeltaTime);
	    }
    }
}
