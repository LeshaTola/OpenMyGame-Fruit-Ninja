using DG.Tweening;
using UnityEngine;

namespace Block
{
	public class Effect : MonoBehaviour
	{
		[SerializeField] private SpriteRenderer spriteRenderer;
		[SerializeField] private float targetScale;
		[SerializeField] private float scaleTime;
		[SerializeField] private float fadeTime;

		private float targetFade = 0f;

		public void Init(Sprite sprite)
		{
			transform.localScale = Vector3.zero;
			spriteRenderer.sprite = sprite;
		}

		public void PlayAnimation()
		{
			Sequence sequence = DOTween.Sequence();
			sequence.Append(transform.DOScale(targetScale, scaleTime));
			sequence.Append(spriteRenderer.DOFade(targetFade, fadeTime));
			sequence.onComplete += () => Destroy(gameObject);
		}
	}
}
