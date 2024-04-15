using UnityEngine;

namespace Blocks
{
	public class Visual : MonoBehaviour
	{
		[SerializeField] private SpriteRenderer spriteRenderer;

		public void Init(Sprite sprite)
		{
			spriteRenderer.sprite = sprite;
		}
	}
}
