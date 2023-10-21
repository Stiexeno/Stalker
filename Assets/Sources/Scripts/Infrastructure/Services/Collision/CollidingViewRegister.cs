using System.Collections.Generic;

namespace Roguelite
{
	public class CollidingViewRegister : ICollidingViewRegister
	{
		private Dictionary<int, IEntityView> controllerByInstanceId = new();

		public IEntityView Register(int instanceId, IEntityView entityViewController)
		{
			controllerByInstanceId[instanceId] = entityViewController;
			return entityViewController;
		}

		public void Unregister(int instanceId, IEntityView @object)
		{
			if (controllerByInstanceId.ContainsKey(instanceId))
				controllerByInstanceId.Remove(instanceId);
		}

		public IEntityView Take(int key) =>
			controllerByInstanceId.TryGetValue(key, out IEntityView behaviour)
				? behaviour
				: null;
	}
}