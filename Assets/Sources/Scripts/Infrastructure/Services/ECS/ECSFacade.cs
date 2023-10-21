using Entitas;

namespace Roguelite
{
    public class ECSFacade : IECSFacade, ISystem
    {
	    private readonly Contexts contexts;
	    private readonly UpdateSystems updateSystems;
	    private readonly FixedUpdateSystems fixedUpdateSystems;

	    public ECSFacade(
		    Contexts contexts,
		    UpdateSystems updateSystems,
		    FixedUpdateSystems fixedUpdateSystems)
	    {
		    this.contexts = contexts;
		    this.updateSystems = updateSystems;
		    this.fixedUpdateSystems = fixedUpdateSystems;
	    }
	    
	    public void Initialize()
	    {
		    updateSystems.Initialize();
		    fixedUpdateSystems.Initialize();
		    
		    updateSystems.ActivateReactiveSystems();
		    fixedUpdateSystems.ActivateReactiveSystems();
	    }

	    public void Reset()
	    {
		    updateSystems.Cleanup();
		    updateSystems.DeactivateReactiveSystems();
		    updateSystems.ClearReactiveSystems();
		    
		    fixedUpdateSystems.Cleanup();
		    fixedUpdateSystems.DeactivateReactiveSystems();
		    fixedUpdateSystems.ClearReactiveSystems();
		    
		    contexts.Reset();
	    }
    }
}
