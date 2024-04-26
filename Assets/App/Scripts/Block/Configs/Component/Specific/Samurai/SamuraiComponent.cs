using Assets.App.Scripts.General;
using Spawn;
using Spawn.Progressor;
using System.Collections;
using UnityEngine;

namespace Blocks.Configs.Component
{
	[CreateAssetMenu(fileName = "SamuraiComponent", menuName = "Configs/Blocks/Components/Specific/Samurai/SamuraiComponent")]
	public class SamuraiComponent : BasicComponent
	{
		[SerializeField, Min(0)] private int bonusTimer;
		[SerializeField, Min(0)] private float blockCountMultiplier;
		[SerializeField, Min(0)] private float blockCooldownMultiplier;
		[SerializeField, Min(0)] private float packCooldownMultiplier;
		[SerializeField] private BlockSpawnConfig blockSpawnConfig;

		public bool IsActive { get; private set; } = false;
		private int timer;
		private IProgressor currentProgressor;

		public override void Execute(Block block)
		{
			IsActive = false;

			if (IsActive)
			{
				timer = bonusTimer;
				return;
			}

			StartBonus();
		}

		public void StartBonus()
		{
			IsActive = true;
			Context.UiContext.SamuraiUI.Show();

			Context.HealthController.enabled = false;

			currentProgressor = Context.Spawner.Progressor;
			currentProgressor.StopProgression();

			SimpleProgressor newProgressor = GetNewProgressor();
			Context.Spawner.SwapProgressor(newProgressor);
			Context.Spawner.ResetComponent();

			Context.BonusController.StartCoroutine(BonusCoroutine());
		}

		private IEnumerator BonusCoroutine()
		{
			timer = bonusTimer;
			var timerStep = new WaitForSeconds(1);
			while (timer > 0)
			{
				yield return timerStep;
				timer--;
				Context.UiContext.SamuraiUI.UpdateTimer(timer);
			}
			StopBonus();
		}

		public void StopBonus()
		{
			IsActive = false;
			Context.UiContext.SamuraiUI.Hide();

			Context.HealthController.enabled = true;

			Context.Spawner.SwapProgressor(currentProgressor);
			currentProgressor.ContinueProgression();
		}

		private SimpleProgressor GetNewProgressor()
		{
			SpawnConfig newConfig;

			var currentConfig = Context.Spawner.Progressor.Config;
			newConfig = currentConfig.Copy(
				currentConfig,
				blockSpawnConfig,
				blockCountMultiplier,
				blockCooldownMultiplier,
				packCooldownMultiplier);

			SimpleProgressor newProgressor = new();
			newProgressor.Init(newConfig, Context.Spawner);
			return newProgressor;
		}

	}
}
