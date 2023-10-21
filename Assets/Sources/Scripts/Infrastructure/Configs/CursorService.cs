using UnityEngine;

namespace Roguelite
{
	public enum CursorType { Default, Attack, Interact, Loot, Talk, Walk }

	public class CursorService : ICursorService
	{
		private CursorConfig config;

		public CursorService(CursorConfig config)
		{
			this.config = config;
			
			SetCursor(CursorType.Default);
		}

		public void SetCursor(CursorType cursorType)
		{
			Texture2D cursor = config.GetCursor(cursorType);
			Cursor.SetCursor(cursor, Vector2.one * 16, CursorMode.Auto);
		}
	}
}