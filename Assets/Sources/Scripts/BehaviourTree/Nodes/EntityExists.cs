using Framework.Bot.ECS;

namespace Roguelite
{
	public class EntityExists : ECSDecorator
	{
		//EntityExists

		protected override bool DryRun()
		{
			return ownerEntity != null && ownerEntity.GetComponents().Length > 0;
		}
	}
}