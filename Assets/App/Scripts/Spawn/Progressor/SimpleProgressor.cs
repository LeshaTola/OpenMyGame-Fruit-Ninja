using System.Collections;
using UnityEngine;

namespace Spawn.Progressor
{
	public class SimpleProgressor : IProgressor
	{
		private SpawnConfig config;
		private Spawner spawner;
		private float fruitCount;

		private Coroutine progressionCoroutine;

		public int FruitCount { get => (int)fruitCount; }
		public float FruitCooldown { get; private set; }
		public float PackCooldown { get; private set; }
		public SpawnConfig Config { get => config; }

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

				if (fruitCount > config.FruitsCount.Range.Min && fruitCount < config.FruitsCount.Range.Max)
					fruitCount += config.FruitsCount.Progression;

				if (FruitCooldown > config.FruitCooldown.Range.Min && FruitCooldown < config.FruitCooldown.Range.Max)
					FruitCooldown += config.FruitCooldown.Progression;

				if (PackCooldown > config.PackCooldown.Range.Min && PackCooldown < config.PackCooldown.Range.Max)
					PackCooldown += config.PackCooldown.Progression;
			}
		}

		public void StopProgression()
		{
			if (progressionCoroutine != null)
			{
				spawner.StopCoroutine(progressionCoroutine);
			}
		}

		public void ContinueProgression()
		{
			progressionCoroutine = spawner.StartCoroutine(ProgressCoroutine());
		}

		public void ResetComponent()
		{
			StopProgression();

			fruitCount = config.FruitsCount.StartValue;
			FruitCooldown = config.FruitCooldown.StartValue;
			PackCooldown = config.PackCooldown.StartValue;

			ContinueProgression();
		}
	}
}
