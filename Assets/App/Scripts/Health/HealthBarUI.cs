using General;
using System.Collections.Generic;
using UnityEngine;

namespace Health
{
	public class HealthBarUI : MonoBehaviour, IInitable
	{
		[SerializeField] private HealthController controller;
		[SerializeField] private HealthIconUI healthIconsTemplate;
		[SerializeField] private Transform container;

		private int lastHealthPosition;
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

		public Vector2 GetNextHeartPosition()
		{
			int position = lastHealthPosition;
			if (position >= healthIcons.Count - 1)
			{
				return healthIcons[healthIcons.Count - 1].transform.position;
			}
			lastHealthPosition++;
			return healthIcons[lastHealthPosition].transform.position;
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
			lastHealthPosition = health - 1;
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