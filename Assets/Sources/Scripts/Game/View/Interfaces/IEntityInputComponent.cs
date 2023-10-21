using UnityEngine;

namespace Roguelite
{
    public interface IEntityInputComponent : IEntityComponent
    {
        Vector2 LookDirection { get; }
        Vector2 Velocity { get; }
    }
}
