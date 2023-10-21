using Framework;
using Framework.StateMachine;
using UnityEngine;

namespace Roguelite
{
	public class GameLoopState : IState, IEnter, IProcessable, IFixedProcessable
	{
		private IECSFacade ecsFacade;
		private UpdateSystems updateSystems;
		private FixedUpdateSystems fixedUpdateSystems;

		public GameLoopState(
			IECSFacade ecsFacade,
			UpdateSystems updateSystems,
			FixedUpdateSystems fixedUpdateSystems)
		{
			this.fixedUpdateSystems = fixedUpdateSystems;
			this.updateSystems = updateSystems;
			this.ecsFacade = ecsFacade;
		}
		
		public void Enter()
		{
			ecsFacade.Initialize();
		}
		
		public void Process(in float deltaTime)
		{
			updateSystems.Execute();
			updateSystems.Cleanup();
		}

		public void FixedProcess(in float deltaTime)
		{
			fixedUpdateSystems.Execute();
			fixedUpdateSystems.Cleanup();
		}
	}
}