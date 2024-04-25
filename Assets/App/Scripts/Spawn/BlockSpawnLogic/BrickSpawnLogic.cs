using Blocks;
using System.Collections.Generic;
using UnityEngine;

namespace Spawn.BlockSpawnLogic
{
	[CreateAssetMenu(fileName = "BrickSpawnLogic", menuName = "Configs/Blocks/SpawnLogic/BrickSpawnLogic")]
	public class BrickSpawnLogic : BasicSpawnLogic
	{
		[SerializeField] private int maxCount;
		public override bool CanSpawn(List<Block> pack)
		{
			if (!IsEnough(pack))
			{
				return true;
			}

			return false;
		}

		private bool IsEnough(List<Block> pack)
		{
			var count = 0;

			if (maxCount <= 0)
			{
				return true;
			}

			foreach (var block in pack)
			{
				if (block.Config != config)
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
