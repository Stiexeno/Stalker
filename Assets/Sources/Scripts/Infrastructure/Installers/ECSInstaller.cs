using Framework.Core;

namespace Roguelite
{
    public class ECSInstaller : AbstractInstaller
    {
	    public override void InstallBindings(DiContainer diContainer)
	    {
		    diContainer.Bind<Contexts>().FromInstance(new Contexts());
		    diContainer.Bind<ECSFacade>();
		    diContainer.Bind<UpdateSystems>();
		    diContainer.Bind<FixedUpdateSystems>();
		    diContainer.Bind<IdentifierService>();
		    diContainer.Bind<CollidingViewRegister>();
	    }
    }
}
