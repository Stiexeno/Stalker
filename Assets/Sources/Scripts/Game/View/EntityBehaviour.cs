using Framework;
using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace Roguelite
{
    public abstract class EntityBehaviour2 : MonoBehaviour, IEntityComponent
    {
	    // Serialized fields
	
    	// Private fields
	    
	    private Contexts contexts;
	    private EntityView entityView;

	    // Properties
	    
	    protected GameEntity Entity => entityView.Entity;
	    protected Contexts Context => contexts;
	
    	//EntityBehaviour

	    [Inject]
	    private void Construct(Contexts contexts)
	    {
		    this.contexts = contexts;
	    }
        
	    public void Initialize(EntityView entityView)
	    {
		    this.entityView = entityView;
		    OnInit();
	    }

	    public void Process(in float deltaTime)
	    {
		    OnProcess(deltaTime);
	    }

	    protected virtual void OnEnable()
	    {
	    }

	    protected abstract void OnInit();
	    protected virtual void OnProcess(in float deltaTime) { }
	    protected virtual void OnSetup() { }
    }
}
