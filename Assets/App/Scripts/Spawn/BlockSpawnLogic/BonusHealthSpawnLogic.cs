using Blocks;
using System.Collections.Generic;
using UnityEngine;

namespace Spawn.BlockSpawnLogic
{
	public class BonusHealthSpawnLogic : BasicSpawnLogic
	{
		[Tooltip("The value of health at which the bonus is spawned")]
		[SerializeField] private int minHealth;
		[Tooltip("Percentage of the main pack")]
		[Range(0, 1)][SerializeField] private float packPercent;

		public override bool CanSpawn(List<Block> pack)
		{
			if (context.HealthController.CurrentHealth <= minHealth && !IsEnough(pack))
			{
				return true;
			}

			return false;
		}

		private bool IsEnough(List<Block> pack)
		{
			var count = 0;

			int maxCount = Mathf.RoundToInt(progressor.FruitCount * packPercent);
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
