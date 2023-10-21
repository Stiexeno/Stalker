using Framework.Core;
using UnityEngine;

namespace Roguelite
{
    public class AbstractEntityFactory
    {
        private IAssets assets;
        private Contexts contexts;

        public AbstractEntityFactory(Contexts contexts, IAssets assets)
        {
            this.contexts = contexts;
            this.assets = assets;
        }

        protected EntityView CreateView(GameObject prefab, Vector3 at, Transform parent = null)
        {
            var gameObject = assets.Instantiate(prefab, at, parent);
            var transformRoot = gameObject.transform.root;
            transformRoot.parent = parent;
            
            var view = gameObject.GetComponentInChildren<EntityView>();
            
            view.Init(contexts.game, contexts.game.CreateEntity());
            
            return gameObject.GetComponentInChildren<EntityView>();
        }
    }
}
