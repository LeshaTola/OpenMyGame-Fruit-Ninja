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
		[SerializeField, Min(0)] private float bonusTimer;
		[SerializeField, Min(0)] private float blockCountMultiplier;
		[SerializeField, Min(0)] private float blockCooldownMultiplier;
		[SerializeField, Min(0)] private float packCooldownMultiplier;
		[SerializeField] private BlockSpawnConfig blockSpawnConfig;

		public bool IsActive { get; private set; } = false;
		private float timer;
		private IProgressor currentProgressor;

		public override void Execute(Block block)
		{
			if (IsActive)
			{
				timer = bonusTimer;
				return;
			}

			currentProgressor = Context.Spawner.Progressor;
			var currentConfig = Context.Spawner.Progressor.Config;
			SpawnConfig newConfig = currentConfig.Copy(
				currentConfig,
				blockSpawnConfig,
				blockCountMultiplier,
				blockCooldownMultiplier,
				packCooldownMultiplier);

			SimpleProgressor newProgressor = new();
			newProgressor.Init(newConfig, Context.Spawner);

			Context.Spawner.SwapProgressor(newProgressor);
			StartBonus();
		}

		private void StartBonus()
		{
			Context.Spawner.StartCoroutine(BonusCoroutine());
		}

		private IEnumerator BonusCoroutine()
		{
			IsActive = true;
			timer = bonusTimer;
			while (timer > 0)
			{
				yield return null;
				timer -= Time.deltaTime;
			}
			IsActive = false;
			Context.Spawner.SwapProgressor(currentProgressor);
		}

	}
}
