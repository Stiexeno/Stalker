using System;
using Framework.Core;
using UnityEngine;

namespace Roguelite
{
	public class CursorConfig : AbstractConfig
	{
		public CursorHolder[] cursors;

		public Texture2D GetCursor(CursorType type)
		{
			foreach (var cursor in cursors)
			{
				if (cursor.type == type)
				{
					return cursor.texture;
				}
			}

			throw new Exception($"Cursor with type {type} not found");
		}
	}

	[Serializable]
	public struct CursorHolder
	{
		public CursorType type;
		public Texture2D texture;
	}
}