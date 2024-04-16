using System.Collections.Generic;
using UnityEngine;

namespace Health
{
	public class HealthUI : MonoBehaviour
	{
		[SerializeField] private HealthController controller;
		[SerializeField] private GameObject template;
		[SerializeField] private Transform container;

		private List<GameObject> healthIcons;

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
			HideChilds();
			for (int i = 0; i < health; i++)
			{
				healthIcons[i].SetActive(true);
			}
		}

		private void OnHealthChanged(int health)
		{
			UpdateUI(health);
		}

		private void HideChilds()
		{
			foreach (var icon in healthIcons)
			{
				icon.SetActive(false);
			}
		}

		private void CreateUI()
		{
			healthIcons = new();
			for (int i = 0; i < controller.MaxHealth; i++)
			{
				var healthIcon = Instantiate(template, container);
				healthIcons.Add(healthIcon);
			}
			HideChilds();
		}
	}
}