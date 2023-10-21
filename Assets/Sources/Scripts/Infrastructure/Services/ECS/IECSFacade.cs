using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace Roguelite
{
	public interface IECSFacade
	{
		void Initialize();
		void Reset();
	}
}