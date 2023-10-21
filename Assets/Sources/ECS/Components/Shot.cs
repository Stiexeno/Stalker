using Entitas;
using Entitas.CodeGeneration.Attributes;

[Event(EventTarget.Self), Cleanup(CleanupMode.RemoveComponent)]
public sealed class Shot : IComponent
{
}