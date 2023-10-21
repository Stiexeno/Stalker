using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace Roguelite
{
	public interface ICursorService
	{
		void SetCursor(CursorType cursorType);
	}
}