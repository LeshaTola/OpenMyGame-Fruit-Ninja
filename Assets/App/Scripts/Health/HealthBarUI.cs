using System.Collections.Generic;
using UnityEngine;

namespace Health
{
	public class HealthBarUI : MonoBehaviour
	{
		[SerializeField] private HealthController controller;
		[SerializeField] private HealthIconUI healthIconsTemplate;
		[SerializeField] private Transform container;

		private List<HealthIconUI> healthIcons;

		public void Init()
		{
			CreateUI();
			controller.OnHealthChanged += OnHealthChanged;
		}

		private void OnDestroy()
		{
			controller.OnHealthChanged -= OnHealthChanged;
		}

		private void UpdateUI(int health)
		{
			for (int i = health; i < controller.MaxHealth; i++)
			{
				healthIcons[i].Hide();
			}

			for (int i = 0; i < health; i++)
			{
				healthIcons[i].Show();
			}
		}

		private void OnHealthChanged(int health)
		{
			UpdateUI(health);
		}

		private void CreateUI()
		{
			healthIcons = new();
			for (int i = 0; i < controller.MaxHealth; i++)
			{
				var healthIcon = Instantiate(healthIconsTemplate, container);
				healthIcon.Init();
				healthIcons.Add(healthIcon);
			}
			healthIcons.Reverse();
		}
	}
}