using UnityEngine;

namespace Blocks.Logic
{
	public interface IBlock
	{
		public void Slice(Vector2 delta);
		public void Kill();
	}
}
