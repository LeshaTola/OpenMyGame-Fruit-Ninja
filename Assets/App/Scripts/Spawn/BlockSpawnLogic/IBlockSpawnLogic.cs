using Assets.App.Scripts.General;
using Blocks;
using Spawn.Progressor;
using System.Collections.Generic;

namespace Spawn.BlockSpawnLogic
{
	public interface IBlockSpawnLogic
	{
		public bool CanSpawn(List<Block> pack);
		public void Init(IProgressor progressor, Config config, Context context);
	}
}
