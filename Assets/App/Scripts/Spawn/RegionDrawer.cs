using General;
using UnityEngine;

namespace Spawn
{
	public class RegionDrawer : MonoBehaviour
	{
		[SerializeField] Spawner spawner;

		private void OnDrawGizmos()
		{
			foreach (Region.Region region in spawner.Regions)
			{
				if (region == null)
				{
					continue;
				}
				DrawRegion(region);
			}
		}

		public void DrawRegion(Region.Region region)
		{
			Gizmos.color = region.Color;

			ScreenCoordinateConverter.Instance.GetRegionBounds(region, out Vector2 startPosition, out Vector2 endPosition);
			Gizmos.DrawLine(startPosition, endPosition);

			var middlePosition = (startPosition + endPosition) / 2;
			Vector2 minDirection = Quaternion.Euler(0, 0, region.MinAngle) * Vector3.up;
			Gizmos.DrawRay(middlePosition, minDirection);

			Vector2 maxDirection = Quaternion.Euler(0, 0, region.MaxAngle) * Vector3.up;
			Gizmos.DrawRay(middlePosition, maxDirection);
		}
	}
}
