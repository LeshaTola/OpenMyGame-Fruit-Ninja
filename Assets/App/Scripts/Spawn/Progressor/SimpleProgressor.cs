using System.Collections;
using UnityEngine;

namespace Spawn.Progressor
{
	public class SimpleProgressor : IProgressor
	{
		private SpawnConfig config;
		private Spawner spawner;
		private float fruitCount;

		public int FruitCount { get => (int)fruitCount; }

		public float FruitCooldown { get; private set; }

		public float PackCooldown { get; private set; }

		public void Init(SpawnConfig config, Spawner spawner)
		{
			this.config = config;
			this.spawner = spawner;
		}

		private IEnumerator ProgressCoroutine()
		{
			float progressTime = config.TimeBetweenProgressions;
			var progressTimer = new WaitForSeconds(progressTime);
			while (true)
			{
				yield return progressTimer;

				if (fruitCount > config.MinFruitCount && fruitCount < config.MaxFruitCount)
					fruitCount += config.FruitCountProgression;

				if (FruitCooldown > config.MinFruitCooldown && FruitCooldown < config.MaxFruitCooldown)
					FruitCooldown += config.FruitCooldownProgression;

				if (PackCooldown > config.MinPackCooldown && PackCooldown < config.MaxPackCooldown)
					PackCooldown += config.PackCooldownProgression;
			}
		}

		public void ResetComponent()
		{
			spawner.StopAllCoroutines();
			fruitCount = config.StartFruitCount;
			FruitCooldown = config.StartFruitCooldown;
			PackCooldown = config.StartPackCooldown;

			spawner.StartCoroutine(ProgressCoroutine());
		}
	}
}
