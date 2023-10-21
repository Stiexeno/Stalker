using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace Roguelite
{
    public interface IEffectFactory
    {
        Effect Take(string id, Vector3 position);
    }
}
