namespace Roguelite
{
    public interface ICollidingViewRegister
    {
	    IEntityView Register(int instanceId, IEntityView entityViewController);
	    void Unregister(int instanceId, IEntityView @object);
	    IEntityView Take(int key);
    }
}
