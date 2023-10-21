using Entitas;

namespace Roguelite
{
	public interface IView
	{
		void Process(in float deltaTime);
		GameEntity Entity { get; }
	}
}