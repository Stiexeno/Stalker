using UnityEngine;

namespace Roguelite
{
    public interface IEntityInputComponent : IEntityComponent
    {
        Vector2 LookDirection { get; set;}
        Vector2 Velocity { get; set;}
    }
}
