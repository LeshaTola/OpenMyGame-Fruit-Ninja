using General;
using System;
using UnityEngine;

namespace Health
{
	public class HealthController : MonoBehaviour, IResettable
	{
		public event Action<int> OnHealthChanged;
		public event Action OnDeath;

		[SerializeField] private int maxHealth;
		[SerializeField] private int defaultHealth;

		private int currentHealth = 0;

		public int MaxHealth { get => maxHealth; }

		public void AddHealth(int health)
		{
			if (health <= 0)
			{
				return;
			}

			currentHealth += health;

			if (currentHealth > maxHealth)
			{
				currentHealth = maxHealth;
			}

			OnHealthChanged?.Invoke(currentHealth);
		}

		public void ReduceHealth(int health)
		{
			if (health <= 0)
			{
				return;
			}
			currentHealth -= health;

			if (currentHealth <= 0)
			{
				currentHealth = 0;
				OnDeath?.Invoke();
			}
			OnHealthChanged?.Invoke(currentHealth);
		}

		public void ResetComponent()
		{
			AddHealth(defaultHealth);
		}
	}
}
