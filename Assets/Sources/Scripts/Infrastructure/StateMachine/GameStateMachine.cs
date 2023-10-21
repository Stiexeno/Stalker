using Framework.StateMachine;

namespace Roguelite
{
	public class GameStateMachine : StateMachine, IGameStateMachine
	{
		public GameStateMachine(IStatesFactory statesFactory) : base(statesFactory)
		{
		}
	}
}