using System;

namespace Roguelite
{
    public class Player : IPlayer
    {
	    public EntityView EntityView { get; set; }
	    
	    public event Action<EntityView> OnPlayerCreated;
	    
	    public void CreatePlayer(EntityView entityView)
	    {
		    EntityView = entityView;
		    OnPlayerCreated?.Invoke(EntityView);
	    }
    }
}
