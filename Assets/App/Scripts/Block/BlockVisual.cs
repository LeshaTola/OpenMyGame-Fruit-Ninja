using UnityEngine;

public class BlockVisual : MonoBehaviour
{
	[SerializeField] private SpriteRenderer spriteRenderer;

	public void Init(Sprite sprite)
	{
		spriteRenderer.sprite = sprite;
	}
}
