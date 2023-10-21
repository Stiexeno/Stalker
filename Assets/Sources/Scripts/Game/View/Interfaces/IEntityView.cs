using Entitas;

namespace Roguelite
{
	public interface IEntityView
	{
		void Process(in float deltaTime);
		GameEntity Entity { get; }
	}
}