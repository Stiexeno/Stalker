using System.Collections.Generic;

namespace Roguelite
{
	public class CollidingViewRegister : ICollidingViewRegister
	{
		private Dictionary<int, IView> controllerByInstanceId = new();

		public IView Register(int instanceId, IView viewController)
		{
			controllerByInstanceId[instanceId] = viewController;
			return viewController;
		}

		public void Unregister(int instanceId, IView @object)
		{
			if (controllerByInstanceId.ContainsKey(instanceId))
				controllerByInstanceId.Remove(instanceId);
		}

		public IView Take(int key) =>
			controllerByInstanceId.TryGetValue(key, out IView behaviour)
				? behaviour
				: null;
	}
}