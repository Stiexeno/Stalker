using Roguelite;

namespace Sources.ECS.Features
{
	public sealed class BehaviourFeature : Feature
	{
		public BehaviourFeature(Contexts contexts, ISystemFactory systemFactory)
		{
			Add(systemFactory.Create<HandleWanderAddedSystem>(contexts));
			Add(systemFactory.Create<WanderSystem>(contexts));
		}
	}
}