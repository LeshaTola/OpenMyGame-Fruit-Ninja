using Blocks;
using System;
using UnityEngine;

namespace Health
{
	public class HealthController : MonoBehaviour
	{
		public event Action<int> OnHealthChanged;
		public event Action OnDeath;

		[SerializeField] private int maxHealth;
		[SerializeField] private int defaultHealth;
		[SerializeField] private DeathLine deathLine;

		private int currentHealth = 0;

		public int MaxHealth { get => maxHealth; }

		public void Init()
		{
			AddHealth(defaultHealth);
			deathLine.OnBlockDestroy += OnBlockDestroy;
		}

		private void OnDestroy()
		{
			deathLine.OnBlockDestroy -= OnBlockDestroy;
		}

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

		private void OnBlockDestroy()
		{
			ReduceHealth(1);
		}
	}
}
