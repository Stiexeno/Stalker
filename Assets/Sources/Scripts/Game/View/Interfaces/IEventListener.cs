using Entitas;

namespace Roguelite
{
	public interface IEventListener
	{
		void RegisterListeners(IEntity entity);
		void UnregisterListeners(IEntity entity);
	}
}