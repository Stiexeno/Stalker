namespace Roguelite
{
    public interface ICollidingViewRegister
    {
	    IView Register(int instanceId, IView viewController);
	    void Unregister(int instanceId, IView @object);
	    IView Take(int key);
    }
}
