using UnityEngine;

namespace Blocks
{
	public enum RotationDirection
	{
		Clockwise,
		Counterclockwise,
		Both
	}

	public enum ScaleMode
	{
		Increase,
		Decrease,
		Both
	}

	[CreateAssetMenu(fileName = "BlockAnimationConfig", menuName = "Configs/Block/Animation")]
	public class AnimationConfig : ScriptableObject
	{
		[Header("Spin")]
		[SerializeField] private float minSpinSpeed;
		[SerializeField] private float maxSpinSpeed;
		[SerializeField] private RotationDirection rotationDirection;

		[Header("Scale")]

		[SerializeField] private float minScaleSpeed;
		[SerializeField] private float maxScaleSpeed;
		[SerializeField] private ScaleMode scaleMode;

		public float MinSpinSpeed { get => minSpinSpeed; }
		public float MaxSpinSpeed { get => maxSpinSpeed; }
		public RotationDirection RotationDirection { get => rotationDirection; }

		public float MinScaleSpeed { get => minScaleSpeed; }
		public float MaxScaleSpeed { get => maxScaleSpeed; }
		public ScaleMode ScaleMode { get => scaleMode; }
	}
}
