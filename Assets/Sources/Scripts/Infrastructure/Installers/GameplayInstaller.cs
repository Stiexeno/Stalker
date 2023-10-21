using Framework.Core;
using Framework.Shake;

namespace Roguelite
{
    public class GameplayInstaller : AbstractInstaller
    {
	    public override void InstallBindings(DiContainer diContainer)
	    {
		    diContainer.Bind<MainCamera>().FromScene();

		    diContainer.Bind<CursorService>().NonLazy();
		    diContainer.Bind<ViewService>().FromScene();
		    diContainer.Bind<ShakeHandler>().FromScene();

		    diContainer.Bind<EffectFactory>();
	    }
    }
}
