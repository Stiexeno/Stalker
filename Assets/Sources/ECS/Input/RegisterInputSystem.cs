using Entitas;
using UnityEngine;

public class RegisterInputSystem : IInitializeSystem
{
	private readonly InputContext inputContext;

	public RegisterInputSystem(Contexts contexts)
	{
		inputContext = contexts.input;
	}
        
	public void Initialize()
	{
		inputContext.ReplaceMovement(Vector2.zero);
		inputContext.ReplaceAiming(Vector2.zero);
	}
}
