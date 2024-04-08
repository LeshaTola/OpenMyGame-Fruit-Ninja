using System.Collections.Generic;
using UnityEngine;

namespace Block
{
	public class Spawner : MonoBehaviour
	{
		[SerializeField] private List<Region> regions = new List<Region>();


		private Rect cameraRect;

		private void Awake()
		{
			cameraRect = Camera.main.rect;
		}



		private void OnDrawGizmos()
		{
			foreach (Region region in regions)
			{
				if (region == null)
				{
					continue;
				}

				Gizmos.color = Color.red;

				Gizmos.DrawLine(region.StartPosition, region.EndPosition);
				var middlePosition = (region.StartPosition + region.EndPosition) / 2;

				Vector2 minDirection = Quaternion.Euler(0, 0, region.MinAngle) * Vector3.up;
				Gizmos.DrawRay(middlePosition, minDirection);

				Vector2 maxDirection = Quaternion.Euler(0, 0, region.MaxAngle) * Vector3.up;
				Gizmos.DrawRay(middlePosition, maxDirection);
			}
		}
	}
}
