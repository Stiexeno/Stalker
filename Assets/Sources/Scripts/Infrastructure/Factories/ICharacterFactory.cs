using Roguelite.Enums;
using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace Roguelite
{
	public interface ICharacterFactory
	{
		EntityView CreatePlayer(Vector3 at);
		EntityView CreateEnemy(Vector3 at);
	}
}