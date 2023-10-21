using System;
using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace Roguelite
{
    public interface IPlayer
    {
        public EntityView EntityView { get; set; }
        event Action<EntityView> OnPlayerCreated;
        void CreatePlayer(EntityView entityView);
    }
}
