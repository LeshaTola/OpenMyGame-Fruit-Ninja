using System.Collections.Generic;
using UnityEngine;

namespace Health
{
	public class HealthBarUI : MonoBehaviour
	{
		[SerializeField] private HealthIconUI healthIconsTemplate;
		[SerializeField] private Transform container;

		private List<HealthIconUI> healthIcons;

		public Transform Container { get => container; }

		public HealthIconUI GetHeartIcon(int healthPosition)
		{
			return healthIcons[healthPosition];
		}

		public void DeactivateAmount(int currentHealth, int prevHealth)
		{
			for (int i = currentHealth; i < prevHealth; i++)
			{
				healthIcons[i].Hide();
			}
		}

		public void ActivateAmount(int currentHealth, int prevHealth)
		{
			for (int i = prevHealth; i < currentHealth; i++)
			{
				healthIcons[i].Show();
			}
		}

		public void CreateUI(int maxHealth)
		{
			healthIcons = new(maxHealth);
			for (int i = 0; i < maxHealth; i++)
			{
				var healthIcon = Instantiate(healthIconsTemplate, container);
				healthIcon.Init();
				healthIcons.Add(healthIcon);
			}

			DeactivateAmount(0, maxHealth);

			healthIcons.Reverse();
		}
	}
}