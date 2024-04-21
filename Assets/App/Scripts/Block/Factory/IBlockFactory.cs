using Blocks.Configs;
using UnityEngine;

namespace Blocks.Factory
{
	public interface IBlockFactory
	{
		public Block GetBomb(BombConfig config);
		public Block GetFruit(FruitConfig config);
		public Block GetHalf(Sprite sprite, float radius);
	}
}
