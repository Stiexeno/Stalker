using Entitas;

public class PatrolSystem : IExecuteSystem
{
	private readonly Contexts contexts;

	public PatrolSystem(Contexts contexts)
	{
		this.contexts = contexts;
	}

	public void Execute()
	{
	}
}
