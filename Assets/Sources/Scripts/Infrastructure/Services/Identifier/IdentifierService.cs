using System.Collections.Generic;

namespace Roguelite
{
	public class IdentifierService : IIdentifierService
	{
		private Dictionary<Identity, int> idenrifiers = new Dictionary<Identity, int>();

		public int Next(Identity identity)
		{
			if (idenrifiers == null)
			{
				idenrifiers = new Dictionary<Identity, int>();
			}
			
			int last = idenrifiers.ContainsKey(identity) ? idenrifiers[identity] : 0;
			int next = ++last;

			idenrifiers[identity] = next;

			return next;
		}

		public void Reset() => idenrifiers.Clear();
	}
}