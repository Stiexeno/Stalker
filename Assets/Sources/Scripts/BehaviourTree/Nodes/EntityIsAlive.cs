using Framework.Bot.ECS;

namespace Roguelite
{
    public class EntityIsAlive : ECSDecorator
    {
    	//EntityIsAlive
        
	    protected override bool DryRun()
	    {
		    return ownerEntity.isDead == false;
	    }
    }
}
