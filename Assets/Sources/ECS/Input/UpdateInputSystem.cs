using Entitas;
using Framework.Core;
using Roguelite;
using UnityEngine;
using UnityEngine.InputSystem;

public class UpdateInputSystem : IExecuteSystem
{
	private InputContext inputContext;

	private IGroup<GameEntity> playerEntities;

	private PlayerInput playerInput;
	
	private readonly InputAction movementInput;
	private readonly InputAction aimingInput;
	private readonly InputAction attackInput;
	private readonly InputAction reloadInput;

	public UpdateInputSystem(Contexts contexts, PlayerInput playerInput)
	{
		this.playerInput = playerInput;
		inputContext = contexts.input;

		playerEntities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.Transform));
		
		movementInput = playerInput.actions[Constants.Input.Actions.Movement];
		aimingInput = playerInput.actions[Constants.Input.Actions.Aiming];
		attackInput = playerInput.actions[Constants.Input.Actions.Attack];
		reloadInput = playerInput.actions[Constants.Input.Actions.Reload];
	}

	public void Execute()
	{
		inputContext.movementEntity.ReplaceMovement(movementInput.ReadValue<Vector2>());
		
		inputContext.isAttackStarted = inputContext.isAttackPressed == false && attackInput.IsPressed();
		inputContext.isAttackPressed = attackInput.IsPressed();
		
		inputContext.isReloadStarted = inputContext.isReloadPressed == false && reloadInput.IsPressed();
		inputContext.isReloadPressed = reloadInput.IsPressed();
		
		UpdateAiming();
	}

	private void UpdateAiming()
	{
		var aimingDirection = Camera.main.ScreenToWorldPoint(aimingInput.ReadValue<Vector2>()).ToVector2();
		
		if (playerEntities.count > 0)
		{
			var playerEntity = playerEntities.GetEntities()[0];

			aimingDirection -= playerEntity.transform.value.position.ToVector2();
			aimingDirection = Vector2.ClampMagnitude(aimingDirection, 1);
		}
		else
		{
			aimingDirection = Vector2.zero;
		}
		
		inputContext.aimingEntity.ReplaceAiming(aimingDirection);
	}
}