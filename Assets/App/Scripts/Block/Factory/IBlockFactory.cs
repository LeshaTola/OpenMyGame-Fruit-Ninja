using UnityEngine;

namespace Blocks.Factory
{
	public interface IBlockFactory
	{
		public Block GetFruit();
		public Block GetHalf(Sprite sprite, float radius);
		public Block GetBomb();
	}
}
