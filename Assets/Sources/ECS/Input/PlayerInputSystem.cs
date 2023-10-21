using Entitas;
using Roguelite;

public class PlayerInputSystem : IExecuteSystem
{
	private readonly InputContext inputContext;
	private readonly IGroup<GameEntity> players;
	private Contexts contexts;

	public PlayerInputSystem(Contexts contexts)
	{
		this.contexts = contexts;
		this.inputContext = contexts.input;
		players = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.CurrentWeapon));
	}

	public void Execute()
	{
		foreach (var player in players)
		{
			player.isAttacking = inputContext.isAttackPressed;

			if (inputContext.isReloadStarted)
			{
				player.ReloadWeapon(contexts.game);
			}
		}
	}
}
