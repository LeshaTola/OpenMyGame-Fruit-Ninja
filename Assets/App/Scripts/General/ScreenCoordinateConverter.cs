using Region;
using UnityEngine;

namespace General
{
	public class ScreenCoordinateConverter
	{
		private float cameraHeight;
		private float cameraWidth;

		private ScreenCoordinateConverter()
		{
			cameraHeight = Camera.main.orthographicSize;
			cameraWidth = Camera.main.orthographicSize * Camera.main.aspect;
		}

		private static ScreenCoordinateConverter instance;
		public static ScreenCoordinateConverter Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new ScreenCoordinateConverter();
				}
				return instance;
			}
			private set { instance = value; }
		}

		public void GetRegionBounds(Region.Region region, out Vector2 startPosition, out Vector2 endPosition)
		{
			switch (region.Position)
			{
				case RegionPosition.Bottom:
					startPosition = new Vector2(cameraWidth * region.Start, -cameraHeight);
					endPosition = new Vector2(cameraWidth * region.End, -cameraHeight);
					break;
				case RegionPosition.Left:
					startPosition = new Vector2(-cameraWidth, cameraHeight * region.Start);
					endPosition = new Vector2(-cameraWidth, cameraHeight * region.End);
					break;
				case RegionPosition.Right:
					startPosition = new Vector2(cameraWidth, cameraHeight * region.Start);
					endPosition = new Vector2(cameraWidth, cameraHeight * region.End);
					break;
				default:
					startPosition = default;
					endPosition = default;
					break;
			}
		}
	}
}