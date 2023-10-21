using Framework.Core;
using Framework.Generated;
using UnityEngine;

namespace Roguelite
{
	public class CharacterFactory : AbstractEntityFactory, ICharacterFactory
	{
		private PlayerComponent playerBehaviour2;
		private EnemyBehaviour2 enemyBehaviour2;

		public CharacterFactory(Contexts contexts, IAssets assets) : base(contexts, assets)
		{
			playerBehaviour2 = assets.GetPrefab<PlayerComponent>(Assets.Characters.Player);
			//enemyBehaviour2 = assets.GetPrefab<EnemyBehaviour2>(Assets.Enemy);
		}

		public EntityView CreatePlayer(Vector3 at)
		{
			var player = CreateView(playerBehaviour2.gameObject, at);
			return player;
		}
		
		public EntityView CreateEnemy(Vector3 at)
		{
			var enemy = CreateView(enemyBehaviour2.gameObject, at);
			return enemy;
		}
	}
}