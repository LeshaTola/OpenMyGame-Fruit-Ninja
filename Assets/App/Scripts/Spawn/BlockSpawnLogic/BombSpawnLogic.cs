using Blocks;
using Spawn.Progressor;
using System.Collections.Generic;
using UnityEngine;

namespace Spawn.BlockSpawnLogic
{
	public class BombSpawnLogic : IBlockSpawnLogic
	{
		private IProgressor progressor;
		private ConfigProperties bombProperties;

		public BombSpawnLogic(IProgressor progressor, ConfigProperties bombProperties)
		{
			this.progressor = progressor;
			this.bombProperties = bombProperties;
		}

		public bool CanSpawn(List<Block> pack)
		{
			if (!IsEnough(pack))
			{
				if (bombProperties.Chance > Random.value)
				{
					return true;
				}
			}

			return false;
		}

		private bool IsEnough(List<Block> pack)
		{
			var count = 0;

			int maxCount = Mathf.RoundToInt(progressor.FruitCount * bombProperties.MaxCount);
			if (maxCount <= 0)
			{
				return true;
			}

			foreach (var block in pack)
			{
				if (block.Config != bombProperties.Config)
				{
					continue;
				}

				count++;
				if (count >= maxCount)
				{
					return true;
				}
			}

			return false;
		}
	}
}
