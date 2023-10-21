using Framework.Core;
using Framework.Generated;
using UnityEngine;

namespace Roguelite
{
	public class CharacterFactory : AbstractEntityFactory, ICharacterFactory
	{
		private PlayerComponent playerPrefab;
		private EnemyComponent enemyPrefab;

		public CharacterFactory(Contexts contexts, IAssets assets) : base(contexts, assets)
		{
			playerPrefab = assets.GetPrefab<PlayerComponent>(Assets.Characters.Player);
			enemyPrefab = assets.GetPrefab<EnemyComponent>(Assets.Characters.Enemy);
		}

		public EntityView CreatePlayer(Vector3 at)
		{
			var player = CreateView(this.playerPrefab.gameObject, at);
			return player;
		}
		
		public EntityView CreateEnemy(Vector3 at)
		{
			var enemy = CreateView(this.enemyPrefab.gameObject, at);
			return enemy;
		}
	}
}