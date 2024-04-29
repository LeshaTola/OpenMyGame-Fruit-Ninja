using Blocks.Configs.Component.Specific;
using System.Collections.Generic;
using UnityEngine;

namespace Scenes.GamePlay.General
{
	public class BonusController : MonoBehaviour
	{
		public List<IBonusComponent> bonuses = new();

		private void Update()
		{
			for (int i = 0; i < bonuses.Count; i++)
			{
				if (!bonuses[i].IsValid)
				{
					RemoveBonus(bonuses[i]);
					continue;
				}
				bonuses[i].UpdateBonus();
			}
		}

		public void AddBonus(IBonusComponent bonus)
		{
			bonuses.Add(bonus);
			bonus.StartBonus();
		}

		public void RemoveBonus(IBonusComponent bonus)
		{
			bonuses.Remove(bonus);
			bonus.StopBonus();
		}

		public bool IsContains(IBonusComponent bonus)
		{
			return bonuses.Contains(bonus);
		}

		public void CleanUp()
		{
			foreach (var bonus in bonuses)
			{
				bonus.StopBonus();
			}
			bonuses.Clear();
		}
	}
}
