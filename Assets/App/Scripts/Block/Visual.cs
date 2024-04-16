using UnityEngine;

namespace Blocks
{
	public class Visual : MonoBehaviour
	{
		[SerializeField] private SpriteRenderer spriteRenderer;
		[SerializeField] private Animation blockAnimation;
		[SerializeField] private Shadow shadow;

		public void Init(Sprite sprite)
		{
			spriteRenderer.sprite = sprite;

			blockAnimation.Init(transform.rotation, transform.localScale);
			shadow.Init(sprite);
		}

		public void RestartAnimation()
		{
			blockAnimation.Restart();
		}
	}
}
