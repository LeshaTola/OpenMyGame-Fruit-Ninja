using Blocks;
using System.Collections.Generic;

namespace Spawn.BlockSpawnLogic
{
	public interface IBlockSpawnLogic
	{
		public bool CanSpawn(List<Block> pack);
	}
}
