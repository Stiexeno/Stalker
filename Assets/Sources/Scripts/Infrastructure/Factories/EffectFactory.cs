using System.Collections.Generic;
using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace Roguelite
{
    public class EffectFactory : IEffectFactory
    {
        private List<Effect> effects = new List<Effect>();
        
        public Effect Take(string id, Vector3 position)
        {
            if (effects == null)
            {
                effects = new List<Effect>();
            }
            
            foreach (var effect in effects)
            {
                if (effect.Id == id && !effect.gameObject.activeSelf)
                {
                    effect.Take(id, position);
                    return effect;
                }
            }
            
            var newEffect = Object.Instantiate(Resources.Load<Effect>(id));
            newEffect.Take(id, position);
            effects.Add(newEffect);
            
            return newEffect;
        }
    }
}
