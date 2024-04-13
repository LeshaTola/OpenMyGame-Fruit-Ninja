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

		public static int GetRotationSign(RotationDirection direction)
		{
			switch (direction)
			{
				case RotationDirection.Clockwise:
					return 1;
				case RotationDirection.Counterclockwise:
					return -1;
				case RotationDirection.Both:
					return Random.Range(0, 2) == 0 ? 1 : -1;
				default:
					Debug.LogError("Unsupported rotation direction: " + direction);
					return 0;
			}
		}

		public static int GetScaleSign(ScaleMode mode)
		{
			switch (mode)
			{
				case ScaleMode.Increase:
					return 1;
				case ScaleMode.Decrease:
					return -1;
				case ScaleMode.Both:
					return Random.Range(0, 2) == 0 ? 1 : -1;
				default:
					Debug.LogError("Unsupported scale mode: " + mode);
					return 0;
			}
		}
	}
}
