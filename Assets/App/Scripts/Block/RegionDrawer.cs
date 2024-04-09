using UnityEngine;

namespace Block
{
	public class RegionDrawer
	{
		public static void DrawRegion(Region region)
		{
			region.GetRegionBounds(out Vector2 startPosition, out Vector2 endPosition);
			Gizmos.DrawLine(startPosition, endPosition);

			var middlePosition = (startPosition + endPosition) / 2;
			Vector2 minDirection = Quaternion.Euler(0, 0, region.MinAngle) * Vector3.up;
			Gizmos.DrawRay(middlePosition, minDirection);

			Vector2 maxDirection = Quaternion.Euler(0, 0, region.MaxAngle) * Vector3.up;
			Gizmos.DrawRay(middlePosition, maxDirection);
		}
	}
}
