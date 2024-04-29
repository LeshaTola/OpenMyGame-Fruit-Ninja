using Assets.App.Scripts.General;
using Blocks.Configs.Component.Specific;
using Spawn;
using Spawn.Progressor;
using UnityEngine;

namespace Blocks.Configs.Component
{
	public class SamuraiComponent : BasicComponent, IBonusComponent
	{
		[SerializeField, Min(0)] private int bonusTimer;
		[SerializeField, Min(0)] private float blockCountMultiplier;
		[SerializeField, Min(0)] private float blockCooldownMultiplier;
		[SerializeField, Min(0)] private float packCooldownMultiplier;
		[SerializeField] private BlockSpawnConfig blockSpawnConfig;

		public bool IsValid { get; private set; }

		private float timer;
		private IProgressor currentProgressor;

		public override void Execute(Block block)
		{
			if (Context.BonusController.IsContains(this))
			{
				timer = bonusTimer;
				return;
			}

			Context.BonusController.AddBonus(this);
		}

		public void StartBonus()
		{
			IsValid = true;

			timer = bonusTimer;
			Context.UiContext.SamuraiUI.UpdateTimer((int)timer);
			Context.UiContext.SamuraiUI.Show();

			Context.HealthController.enabled = false;

			currentProgressor = Context.Spawner.Progressor;
			currentProgressor.StopProgression();

			SimpleProgressor newProgressor = GetNewProgressor();
			Context.Spawner.SwapProgressor(newProgressor);
			Context.Spawner.ResetComponent();

		}

		public void UpdateBonus()
		{
			if (timer <= 0)
			{
				IsValid = false;
			}

			timer -= Time.deltaTime;
			Context.UiContext.SamuraiUI.UpdateTimer((int)timer);
		}

		public void StopBonus()
		{
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
