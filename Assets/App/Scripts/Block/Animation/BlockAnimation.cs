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
			transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
		}

		public void Restart()
		{

			transform.rotation = startRotation;
			transform.localScale = startScale;

			scaleSpeed = Vector3.one * Random.Range(config.MinScaleSpeed, config.MaxScaleSpeed) * AnimationConfig.GetScaleSign(config.ScaleMode);
			rotationSpeed = Random.Range(config.MinSpinSpeed, config.MaxSpinSpeed) * AnimationConfig.GetRotationSign(config.RotationDirection);
		}

		private void Scale()
		{
			transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale + scaleSpeed, Time.deltaTime);
		}
	}
}