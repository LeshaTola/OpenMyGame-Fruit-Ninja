using UnityEngine;

namespace Blocks
{
	public class Shadow : MonoBehaviour
	{
		[SerializeField] private Vector3 sunPosition;
		[SerializeField] private float aspect;
		[SerializeField] private SpriteRenderer objectVisual;
		[SerializeField] private SpriteRenderer shadowVisual;
		[SerializeField] private Animation blockAnimation;

		private void Start()
		{
			shadowVisual.sprite = objectVisual.sprite;
		}

		private void Update()
		{
			MoveShadow();
		}

		private void MoveShadow()
		{
			shadowVisual.transform.rotation = blockAnimation.transform.rotation;
			//shadowVisual.transform.localScale = blockAnimation.transform.localScale;

			Vector3 shadowDirection = transform.position - sunPosition;
			transform.localPosition = shadowDirection.normalized * aspect * blockAnimation.transform.localScale.x;
		}
	}
}