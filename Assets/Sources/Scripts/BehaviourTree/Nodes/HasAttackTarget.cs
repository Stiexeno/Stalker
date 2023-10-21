using Framework.Bot.ECS;

namespace Roguelite
{
    public class HasAttackTarget : ECSDecorator
    {
        // Serialized fields
	
    	// Private fields
	
    	// Properties
	
    	//HasAttackTarget
        
	    protected override bool DryRun()
	    {
		    return ownerEntity.hasAttackTarget;
	    }
    }
}
