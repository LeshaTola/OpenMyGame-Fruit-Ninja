using General;
using Spawn.Progressor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Spawn
{
	public class Spawner : MonoBehaviour
	{
		[SerializeField] private List<Region.Region> regions;
		[SerializeField] private List<Block.Block> blockTemplates;
		[SerializeField] private SpawnConfig config;

		private IProgressor progressor;

		public IReadOnlyCollection<Region.Region> Regions { get => regions; }

		private void Start()
		{
			progressor = new SimpleProgressor();
			progressor.Init(config, this);
			StartCoroutine(SpawnCoroutine());
		}

		public IEnumerator Spawn()
		{
			Region.Region region = GetRegion();

			var fruitTimer = new WaitForSeconds(progressor.FruitCooldown);
			for (int i = 0; i < progressor.FruitCount; i++)
			{
				yield return fruitTimer;

				Vector2 spawnPosition = GetSpawnPosition(region);

				var block = Instantiate
					(blockTemplates[Random.Range(0, blockTemplates.Count)], spawnPosition, Quaternion.identity);

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

		private Region.Region GetRegion()
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

		private Vector2 GetSpawnPosition(Region.Region region)
		{
			ScreenCoordinateConverter.Instance.GetRegionBounds(region, out Vector2 startPosition, out Vector2 endPosition);
			return Vector2.Lerp(startPosition, endPosition, Random.value);
		}

		private IEnumerator SpawnCoroutine()
		{
			while (true)
			{
				yield return new WaitForSeconds(progressor.PackCooldown);
				yield return Spawn();
			}
		}
	}
}
