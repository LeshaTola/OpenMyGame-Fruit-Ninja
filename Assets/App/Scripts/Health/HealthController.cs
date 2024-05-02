using General;
using System;
using UnityEngine;

namespace Health
{
	public class HealthController : MonoBehaviour, IInitable, IResettable
	{
		public event Action OnDeath;

		[SerializeField] private int maxHealth;
		[SerializeField] private int defaultHealth;
		[SerializeField] private HealthBarUI healthBarUI;

		private int currentHealth = 0;

		public int MaxHealth { get => maxHealth; }
		public int CurrentHealth { get => currentHealth; }

		public void Init()
		{
			healthBarUI.CreateUI(maxHealth);
		}

		public void AddHealth(int health)
		{
			if (health <= 0 || enabled == false)
			{
				return;
			}
			int prevHealth = currentHealth;
			currentHealth += health;

			if (currentHealth > maxHealth)
			{
				currentHealth = maxHealth;
			}

			healthBarUI.ActivateAmount(currentHealth, prevHealth);
		}

		public void ReduceHealth(int health)
		{
			if (health <= 0 || enabled == false)
			{
				return;
			}

			int prevHealth = currentHealth;
			currentHealth -= health;

			if (currentHealth <= 0)
			{
				currentHealth = 0;
				OnDeath?.Invoke();
			}
			healthBarUI.DeactivateAmount(currentHealth, prevHealth);
		}

		public void ResetComponent()
		{
			enabled = true;
			AddHealth(defaultHealth);
		}
	}
}
