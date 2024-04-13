using UnityEngine;

namespace Regions
{

	[CreateAssetMenu(fileName = "RegionConfig", menuName = "Configs/Region")]
	public class Region : ScriptableObject
	{
		[Header("Region")]
		[SerializeField] private Vector2 start;
		[SerializeField] private Vector2 end;

		[SerializeField, Range(-1, 1)] private float xOffset;
		[SerializeField, Range(-1, 1)] private float yOffset;

		[field: SerializeField] public Color Color { get; private set; }
		[field: SerializeField, Range(0, 10)] public int Priority { get; private set; }

		//[Header("Angle")]
		[field: SerializeField] public float MinAngle { get; private set; }
		[field: SerializeField] public float MaxAngle { get; private set; }

		//[Header("Vertical Speed")]
		[field: SerializeField, Min(0)] public float MinVerticalSpeed { get; private set; }
		[field: SerializeField, Min(0)] public float MaxVerticalSpeed { get; private set; }

		//[Header("Horizontal Speed")]
		[field: SerializeField, Min(0)] public float MinHorizontalSpeed { get; private set; }
		[field: SerializeField, Min(0)] public float MaxHorizontalSpeed { get; private set; }

		public Vector2 Start { get => start; }
		public Vector2 End { get => end; }
		public float XOffset { get => xOffset; }
		public float YOffset { get => yOffset; }

		public static Vector2 ToWorldPosition(Camera mainCamera, Region region, Vector2 position)
		{
			var yOffset = region.YOffset * mainCamera.orthographicSize;
			var xOffset = region.XOffset * mainCamera.orthographicSize * mainCamera.aspect;

			return new Vector2(position.x + xOffset, position.y + yOffset);

		}
	}
}
