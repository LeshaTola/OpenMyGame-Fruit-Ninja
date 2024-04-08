using UnityEngine;

namespace Block
{
	[CreateAssetMenu(fileName = "RegionConfig", menuName = "Configs/Region")]
	public class Region : ScriptableObject
	{
		[Header("Region")]
		[field: SerializeField] public Vector2 StartPosition;
		[field: SerializeField] public Vector2 EndPosition;

		[Header("Angle")]
		[field: SerializeField] public float MinAngle;
		[field: SerializeField] public float MaxAngle;

		[Header("Speed")]
		[field: SerializeField] public float MinSpeed;
		[field: SerializeField] public float MaxSpeed;
	}
}
