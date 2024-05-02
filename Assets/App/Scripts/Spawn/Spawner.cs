using Assets.App.Scripts.General;
using Blocks;
using Blocks.Factory;
using General;
using Regions;
using Spawn.Progressor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Spawn
{
	public class Spawner : MonoBehaviour, IResettable
	{
		[SerializeField] private Context context;
		[SerializeField] private List<Region> regions;
		[SerializeField] private SpawnConfig config;
		[SerializeField] private Camera mainCamera;

		private IBlockFactory blockFactory;
		private IProgressor progressor;
		private Coroutine spawnCoroutine;

		public IReadOnlyCollection<Region> Regions { get => regions; }
		public IProgressor Progressor { get => progressor; }

		public void Init(IProgressor progressor, IBlockFactory blockFactory)
		{
			this.progressor = progressor;
			this.blockFactory = blockFactory;
			progressor.Init(config, this);

			SwapProgressor(progressor);
		}

		public void ResetComponent()
		{
			StopSpawner();
			progressor.ResetComponent();
			StartSpawner();
		}

		public void SwapProgressor(IProgressor progressor)
		{
			this.progressor = progressor;

			foreach (var bonus in progressor.Config.BlockSpawnConfig.Bonuses)
			{
				bonus.SpawnLogic.Init(progressor, bonus.Config, context);
			}
		}

		public void StartSpawner()
		{
			spawnCoroutine = StartCoroutine(SpawnCoroutine());
		}

		public void StopSpawner()
		{
			if (spawnCoroutine != null)
			{
				StopCoroutine(spawnCoroutine);
			}
		}

		private Region GetRegion()
		{
			int totalWeight = 0;
			foreach (var region in regions)
			{
				totalWeight += region.Priority;
			}

			int value = Random.Range(1, totalWeight + 1);
			int current = 0;

			foreach (var region in regions)
			{
				current += region.Priority;
				if (current >= value)
				{
					return region;
				}
			}

			return regions.Last();
		}

		private Vector2 GetSpawnPosition(Region region)
		{
			var start = Region.ToWorldPosition(mainCamera, region, region.Start);
			var end = Region.ToWorldPosition(mainCamera, region, region.End);
			return Vector2.Lerp(start, end, Random.value);
		}

		private IEnumerator SpawnCoroutine()
		{
			while (true)
			{
				yield return new WaitForSeconds(progressor.PackCooldown);
				yield return SpawnPack();
			}
		}

		private IEnumerator SpawnPack()
		{
			Region region = GetRegion();

			var fruitTimer = new WaitForSeconds(progressor.FruitCooldown);
			List<Block> pack = new();
			for (int i = 0; i < progressor.FruitCount; i++)
			{
				yield return fruitTimer;

				var block = GetAnyBlock(pack);
				pack.Add(block);

				block.transform.position = GetSpawnPosition(region);

				float randomAngle = Random.Range(region.MinAngle, region.MaxAngle);
				Vector2 pushDirection = Quaternion.Euler(0, 0, randomAngle) * Vector2.up;

				Vector2 speed =
					new Vector2(
						Random.Range(region.MinHorizontalSpeed, region.MaxHorizontalSpeed),
						Random.Range(region.MinVerticalSpeed, region.MaxVerticalSpeed)
						);

				block.Movement.Push(pushDirection * speed);
			}
		}

		private Block GetAnyBlock(List<Block> pack)
		{
			return blockFactory.GetBlock(GetConfigByWeight(pack));
		}

		private Config GetConfigByWeight(List<Block> pack)
		{
			var blockConfig = progressor.Config.BlockSpawnConfig;
			int totalWeight = blockConfig.FruitsWeight;
			foreach (var bonus in blockConfig.Bonuses)
			{
				totalWeight += bonus.Weight;
			}

			List<Config> fruits = blockConfig.Fruits;
			while (true)
			{
				int value = Random.Range(1, totalWeight + 1);
				int current = 0;

				current += blockConfig.FruitsWeight;
				if (current >= value)
				{
					Config fruit = fruits[Random.Range(0, fruits.Count)];
					return fruit;
				}

				Config bonus = GetBonus(pack, blockConfig, value, ref current);
				if (bonus != null)
				{
					return bonus;
				}
			}
		}

		private Config GetBonus(List<Block> pack, BlockSpawnConfig blockConfig, int value, ref int current)
		{
			foreach (var bonus in blockConfig.Bonuses)
			{
				current += bonus.Weight;
				if (current >= value)
				{
					if (bonus.SpawnLogic.CanSpawn(pack))
					{
						return bonus.Config;
					}
					return null;
				}
			}
			return null;
		}
	}
}
