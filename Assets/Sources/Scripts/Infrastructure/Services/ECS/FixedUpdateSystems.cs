namespace Roguelite
{
    public sealed class FixedUpdateSystems : Feature
    {
	    public FixedUpdateSystems(Contexts contexts, ISystemFactory systemFactory)
	    {
		    Add(systemFactory.Create<MovementSystem>(contexts));
		    Add(systemFactory.Create<MovementSlowDownSystem>(contexts));
	    }
    }
}
