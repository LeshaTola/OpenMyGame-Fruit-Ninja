using Assets.App.Scripts.General;
using Blocks;
using Spawn.Progressor;
using System.Collections.Generic;
using UnityEngine;

namespace Spawn.BlockSpawnLogic
{
	public abstract class BasicSpawnLogic : ScriptableObject, IBlockSpawnLogic
	{
		protected IProgressor progressor;
		protected Config config;
		protected Context context;

		public void Init(IProgressor progressor, Config config, Context context)
		{
			this.progressor = progressor;
			this.config = config;
			this.context = context;
		}

		public abstract bool CanSpawn(List<Block> pack);
	}
}
