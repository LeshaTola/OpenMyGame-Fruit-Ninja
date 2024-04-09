using UnityEngine;

namespace Block
{
	public enum RegionPosition
	{
		Bottom,
		Left,
		Right,
	}

	[CreateAssetMenu(fileName = "RegionConfig", menuName = "Configs/Region")]
	public class Region : ScriptableObject
	{
		//[Header("Region")]
		[field: SerializeField] public RegionPosition Position { get; private set; }
		[field: SerializeField, Range(-1, 1)] public float Start { get; private set; }
		[field: SerializeField, Range(-1, 1)] public float End { get; private set; }

		//[Header("Angle")]
		[field: SerializeField] public float MinAngle { get; private set; }
		[field: SerializeField] public float MaxAngle { get; private set; }

		//[Header("Speed")]
		[field: SerializeField] public float MinSpeed { get; private set; }
		[field: SerializeField] public float MaxSpeed { get; private set; }

		public void GetRegionBounds(out Vector2 startPosition, out Vector2 endPosition)
		{
			var defaultHeight = Camera.main.orthographicSize;
			var defaultWidth = Camera.main.orthographicSize * Camera.main.aspect;

			switch (Position)
			{
				case RegionPosition.Bottom:
					startPosition = new Vector2(defaultWidth * Start, -defaultHeight);
					endPosition = new Vector2(defaultWidth * End, -defaultHeight);
					break;
				case RegionPosition.Left:
					startPosition = new Vector2(-defaultWidth, defaultHeight * Start);
					endPosition = new Vector2(-defaultWidth, defaultHeight * End);
					break;
				case RegionPosition.Right:
					startPosition = new Vector2(defaultWidth, defaultHeight * Start);
					endPosition = new Vector2(defaultWidth, defaultHeight * End);
					break;
				default:
					startPosition = default;
					endPosition = default;
					break;
			}
		}
	}
}
