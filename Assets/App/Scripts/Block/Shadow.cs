using UnityEngine;

namespace Block
{
	public class Shadow : MonoBehaviour
	{
		[SerializeField] private Vector3 sunPosition;
		[SerializeField] private float aspect;
		[SerializeField] private SpriteRenderer objectVisual;
		[SerializeField] private SpriteRenderer shadowVisual;
		[SerializeField] private BlockAnimation blockVisual;

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
			shadowVisual.transform.rotation = blockVisual.transform.rotation;
			shadowVisual.transform.localScale = blockVisual.transform.localScale;

			Vector3 shadowDirection = transform.position - sunPosition;
			transform.localPosition = shadowDirection.normalized * aspect * blockVisual.transform.localScale.x;
		}
	}
}