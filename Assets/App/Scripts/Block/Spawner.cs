using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Block
{
	public class Spawner : MonoBehaviour
	{
		[SerializeField] private List<Region> regions = new();
		[SerializeField] private List<BlockMovement> blockTemplates = new();
		[SerializeField] private float cooldown;

		private void Start()
		{
			StartCoroutine(SpawnCoroutine());
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.red;

			foreach (Region region in regions)
			{
				if (region == null)
				{
					continue;
				}

				RegionDrawer.DrawRegion(region);
			}
		}

		public void Spawn()
		{
			Region region = regions[Random.Range(0, regions.Count)];
			Vector2 spawnPosition = GetSpawnPosition(region);

			var block = Instantiate
				(blockTemplates[Random.Range(0, blockTemplates.Count)], spawnPosition, Quaternion.identity);

			float randomAngle = Random.Range(region.MinAngle, region.MaxAngle);
			Vector2 pushDirection = Quaternion.Euler(0, 0, randomAngle) * Vector2.up;

			float speed = Random.Range(region.MinSpeed, region.MaxSpeed);

			block.Push(pushDirection * speed);
		}

		private Vector2 GetSpawnPosition(Region region)
		{
			region.GetRegionBounds(out Vector2 startPosition, out Vector2 endPosition);
			return Vector2.Lerp(startPosition, endPosition, Random.value);
		}

		private IEnumerator SpawnCoroutine()
		{
			var time = new WaitForSeconds(cooldown);
			while (true)
			{
				yield return time;
				Spawn();
			}
		}
	}
}
