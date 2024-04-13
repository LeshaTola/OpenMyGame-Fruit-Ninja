using DG.Tweening;
using UnityEngine;

namespace Blocks
{
	public class BlockAnimation : MonoBehaviour
	{
		[SerializeField] AnimationConfig config;

		private Quaternion startRotation;
		private Vector3 startScale;

		private Vector3 scaleSpeed;
		private float rotationSpeed;

		private void Awake()
		{
			startRotation = transform.rotation;
			startScale = transform.localScale;
		}

		private void Update()
		{
			Scale();
		}

		private void OnDestroy()
		{
			transform.DOKill();
		}

		public void Restart()
		{

			transform.rotation = startRotation;
			transform.localScale = startScale;

			scaleSpeed = Vector3.one * Random.Range(config.MinScaleSpeed, config.MaxScaleSpeed) * GetScaleSign(config.ScaleMode);
			rotationSpeed = Random.Range(config.MinSpinSpeed, config.MaxSpinSpeed);

			transform.DOKill();
			StartRotation();
		}

		private void Scale()
		{
			transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale + scaleSpeed, Time.deltaTime);
		}

		private void StartRotation()
		{
			transform
				.DORotate(new Vector3(0, 0, 360f * GetRotationSign(config.RotationDirection)), 360f / rotationSpeed, RotateMode.FastBeyond360)
				.SetLoops(-1)
				.SetEase(Ease.Linear);
		}

		private static int GetRotationSign(RotationDirection direction)
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

		private static int GetScaleSign(ScaleMode mode)
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