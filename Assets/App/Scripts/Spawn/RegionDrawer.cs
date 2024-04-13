using Regions;
using UnityEngine;

namespace Spawn
{
	public class RegionDrawer : MonoBehaviour
	{
		[SerializeField] private Spawner spawner;
		[SerializeField] private Camera mainCamera;

		private void OnDrawGizmos()
		{
			foreach (Region region in spawner.Regions)
			{
				if (region == null)
				{
					continue;
				}
				DrawRegion(region);
			}
		}

		public void DrawRegion(Region region)
		{
			Gizmos.color = region.Color;

			var start = Region.ToWorldPosition(mainCamera, region, region.Start);
			var end = Region.ToWorldPosition(mainCamera, region, region.End);

			Gizmos.DrawLine(start, end);

			var middlePosition = (start + end) / 2;
			Vector2 minDirection = Quaternion.Euler(0, 0, region.MinAngle) * Vector3.up;
			Gizmos.DrawRay(middlePosition, minDirection);

			Vector2 maxDirection = Quaternion.Euler(0, 0, region.MaxAngle) * Vector3.up;
			Gizmos.DrawRay(middlePosition, maxDirection);
		}
	}
}
