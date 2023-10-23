using System;
using System.Collections;
using Framework.Core;
using Framework.StateMachine;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Roguelite
{
	public class LoadLevelState : IState, IPayloadedEnter<string>, IExit
	{
		private ISceneService sceneService;
		private ICoroutineManager coroutineManager;
		private IGameStateMachine stateMachine;
		private IECSFacade ecsFacade;
		private ICharacterFactory characterFactory;
		private IWeaponFactory weaponFactory;
		private IPlayer player;

		public LoadLevelState(
			ISceneService sceneService, 
			ICoroutineManager coroutineManager,
			IGameStateMachine stateMachine,
			IECSFacade ecsFacade,
			ICharacterFactory characterFactory,
			IWeaponFactory weaponFactory,
			IPlayer player)
		{
			this.player = player;
			this.weaponFactory = weaponFactory;
			this.characterFactory = characterFactory;
			this.ecsFacade = ecsFacade;
			this.stateMachine = stateMachine;
			this.coroutineManager = coroutineManager;
			this.sceneService = sceneService;
		}
		
		public void Enter(string sceneName)
		{
			ecsFacade.Reset();
			
			var currentActiveScene = SceneManager.GetActiveScene().name;

			if (currentActiveScene != sceneName)
			{
				sceneService.LoadScene(sceneName, onLoadded: OnSceneLoaded);
			}
			else
			{
				OnSceneLoaded();
			}
		}

		public void Exit()
		{
		}
		
		private void OnSceneLoaded()
		{
			coroutineManager.Begin(LoadLevel(() =>
			{
				stateMachine.Enter<GameLoopState>();
			}));
		}
		
		private IEnumerator LoadLevel(Action onComplete = null)
		{
			yield return new WaitForSeconds(0.2f);
			
			CreatePlayer();
			onComplete?.Invoke();
		}

		private void CreatePlayer()
		{
			var createdPlayer = characterFactory.CreatePlayer(Vector2.zero);
			this.player.CreatePlayer(createdPlayer);
			weaponFactory.CreateSword(player.EntityView.transform, player.EntityView.Entity);
		}
	}
}