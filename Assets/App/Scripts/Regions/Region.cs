using UnityEngine;

namespace Regions
{

	[CreateAssetMenu(fileName = "RegionConfig", menuName = "Configs/Region")]
	public class Region : ScriptableObject
	{
		[Header("Region")]
		[SerializeField] private Color color = Color.white;
		[SerializeField, Range(0, 10)] private int priority;

		[SerializeField] private Vector2 start;
		[SerializeField] private Vector2 end;

		[SerializeField, Range(-1, 1)] private float xOffset;
		[SerializeField, Range(-1, 1)] private float yOffset;

		[Header("Angle")]
		[SerializeField] private float minAngle;
		[SerializeField] private float maxAngle;

		[Header("Vertical Speed")]
		[SerializeField, Min(0)] private float minVerticalSpeed;
		[SerializeField, Min(0)] private float maxVerticalSpeed;

		[Header("Horizontal Speed")]
		[SerializeField, Min(0)] private float minHorizontalSpeed;
		[SerializeField, Min(0)] private float maxHorizontalSpeed;

		public Color Color { get => color; set => color = value; }
		public int Priority { get => priority; set => priority = value; }
		public Vector2 Start { get => start; }
		public Vector2 End { get => end; }
		public float XOffset { get => xOffset; }
		public float YOffset { get => yOffset; }

		public float MinAngle { get => minAngle; set => minAngle = value; }
		public float MaxAngle { get => maxAngle; set => maxAngle = value; }

		public float MinVerticalSpeed { get => minVerticalSpeed; set => minVerticalSpeed = value; }
		public float MaxVerticalSpeed { get => maxVerticalSpeed; set => maxVerticalSpeed = value; }

		public float MinHorizontalSpeed { get => minHorizontalSpeed; set => minHorizontalSpeed = value; }
		public float MaxHorizontalSpeed { get => maxHorizontalSpeed; set => maxHorizontalSpeed = value; }

		public static Vector2 ToWorldPosition(Camera mainCamera, Region region, Vector2 position)
		{
			var yOffset = region.YOffset * mainCamera.orthographicSize;
			var xOffset = region.XOffset * mainCamera.orthographicSize * mainCamera.aspect;
			return new Vector2(position.x + xOffset, position.y + yOffset);
		}
	}
}
