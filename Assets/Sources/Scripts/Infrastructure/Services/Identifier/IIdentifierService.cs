using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace Roguelite
{
    public interface IIdentifierService
    {
        int Next(Identity identity);
        void Reset();
    }
}

public enum Identity
{
    General
}
