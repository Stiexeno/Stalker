using Framework.Core;
using Framework.StateMachine;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Roguelite
{
	public class BootstrapState : IState, IEnter
	{
		// Private fields

		private string currentActiveScene;
		
		private const int TARGET_FRAME_RATE = 120;
		
		private IGameStateMachine stateMachine;
		private ISceneService sceneService;

		public BootstrapState(IGameStateMachine stateMachine, ISceneService sceneService)
		{
			this.sceneService = sceneService;
			this.stateMachine = stateMachine;
		}
		
		private static void SetTargetFrameRate() => Application.targetFrameRate = TARGET_FRAME_RATE;
		
		public void Enter()
		{
			SetTargetFrameRate();

			currentActiveScene = SceneManager.GetActiveScene().name;
			
			if (currentActiveScene == Constants.Scenes.Gameplay)
			{
				EnterLoadedScene();
				return;
			}
			
			sceneService.LoadScene(Constants.Scenes.Boot, onLoadded: EnterLoadedScene);
		}

		private void EnterLoadedScene()
		{
			var sceneToLoad = Constants.Scenes.Gameplay;
			
			if (Application.isEditor && currentActiveScene != Constants.Scenes.Boot)
			{
				stateMachine.Enter<LoadLevelState, string>(currentActiveScene);
			}
			else
			{
				stateMachine.Enter<LoadLevelState, string>(sceneToLoad);
			}
		}
	}
}