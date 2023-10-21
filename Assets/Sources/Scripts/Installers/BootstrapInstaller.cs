using Framework;
using Framework.Core;
using Framework.Generated;
using UnityEngine.InputSystem;

namespace Roguelite
{
	public class BootstrapInstaller : BootstrapBaseInstaller, IInitializable
	{
		private DiContainer diContainer;

		public override void InstallBindings(DiContainer diContainer)
		{
			this.diContainer = diContainer;
			
			diContainer.Bind<SystemFactory>();
			diContainer.Bind<GameStateMachine>();
			
			diContainer.Bind<PlayerInput>().FromResources(Assets.Input.PlayerInput).DontDestroyOnLoad();
			
			// Factories
			diContainer.Bind<CharacterFactory>();
			diContainer.Bind<ProjectileFactory>();
			diContainer.Bind<WeaponFactory>();
			
			//diContainer.Bind<InputService>();
			
			diContainer.Bind<Player>();
			
			CreateInstance<ECSInstaller>().InstallBindings(diContainer);
		}

		public void Initialize()
		{
			diContainer.Resolve<GameStateMachine>().Enter<BootstrapState>();
		}
	}
}