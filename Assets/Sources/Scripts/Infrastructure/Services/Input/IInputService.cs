using UnityEngine;

namespace Roguelite
{
    public interface IInputService
    {
        Vector2 Movement { get; }
        Vector2 MousePosition { get; }
        bool Mouse0Pressed { get; }
    }
}
