using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Input, Unique, Cleanup(CleanupMode.DestroyEntity)]
public class InputHandler : IComponent
{
	public Vector3 input;
}