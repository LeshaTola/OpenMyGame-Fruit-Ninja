using UnityEngine;

namespace Region
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
		[field: SerializeField] public Color Color { get; private set; }
		[field: SerializeField, Range(0, 10)] public int Priority { get; private set; }
		[field: SerializeField] public RegionPosition Position { get; private set; }
		[field: SerializeField, Range(-1, 1)] public float Start { get; private set; }
		[field: SerializeField, Range(-1, 1)] public float End { get; private set; }

		//[Header("Angle")]
		[field: SerializeField] public float MinAngle { get; private set; }
		[field: SerializeField] public float MaxAngle { get; private set; }

		//[Header("Vertical Speed")]
		[field: SerializeField, Min(0)] public float MinVerticalSpeed { get; private set; }
		[field: SerializeField, Min(0)] public float MaxVerticalSpeed { get; private set; }

		//[Header("Horizontal Speed")]
		[field: SerializeField, Min(0)] public float MinHorizontalSpeed { get; private set; }
		[field: SerializeField, Min(0)] public float MaxHorizontalSpeed { get; private set; }
	}
}
