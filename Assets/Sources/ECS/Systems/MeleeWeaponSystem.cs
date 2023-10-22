using Entitas;

public class MeleeWeaponSystem : IExecuteSystem
{
	private readonly Contexts contexts;

	public MeleeWeaponSystem(Contexts contexts)
	{
		this.contexts = contexts;
	}

	public void Execute()
	{
	}
}
