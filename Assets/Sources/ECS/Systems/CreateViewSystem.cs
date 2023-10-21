using System.Collections.Generic;
using Entitas;
using Framework.Core;
using UnityEngine;

namespace Roguelite
{
	public sealed class CreateViewSystem : ReactiveSystem<GameEntity>
	{
		private readonly Transform parent;
		
		private IAssets assets;

		public CreateViewSystem(Contexts contexts, IAssets assets) : base(contexts.game)
		{
			this.assets = assets;
			parent = new GameObject("Views").transform;
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.Asset);
		}

		protected override bool Filter(GameEntity entity)
		{
			//return entity.hasAsset && !entity.hasView;
			return false;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			//foreach (var entity in entities)
			//{
			//	entity.AddView(InstantiateView(entity));
			//}
		}
	
		//IView InstantiateView(GameEntity entity)
		//{
		//	var assetComponent = entity.asset;
		//	var prefab = assets.InstantiateType<GameObject>(assetComponent.value);
		//	prefab.transform.SetParent(assetComponent.parent ? assetComponent.parent : parent);
		//	prefab.transform.position = assetComponent.position;
//
		//	if (assetComponent.prewarm)
		//		prefab.SetActive(false);
		//	
		//	var view = prefab.GetComponent<IView>();
		//	view.Link(entity);
		//	return view;
		//}
	}
}
