namespace Roguelite
{
	public interface IViewService
	{
		void RemoveView(IEntityView value);
		void RegisterView(IEntityView value);
	}
}