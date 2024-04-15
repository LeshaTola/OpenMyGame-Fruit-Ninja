using UnityEngine;

namespace Blocks
{
	public class Visual : MonoBehaviour
	{
		[SerializeField] private SpriteRenderer spriteRenderer;
		[SerializeField] private Animation blockAnimation;

		public void Init(Sprite sprite)
		{
			spriteRenderer.sprite = sprite;
			blockAnimation.Init(transform.rotation, transform.localScale);
		}

		public void RestartAnimation()
		{
			blockAnimation.Restart();
		}
	}
}
