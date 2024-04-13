using UnityEngine;

namespace Blocks
{
	public class HalfVisual : MonoBehaviour
	{
		[SerializeField] private SpriteRenderer spriteRenderer;
		[SerializeField] private BlockAnimation blockAnimation;

		public void Init(Sprite sprite)
		{
			spriteRenderer.sprite = sprite;
			blockAnimation.Restart();
		}
	}
}