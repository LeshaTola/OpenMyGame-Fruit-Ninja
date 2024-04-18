using DG.Tweening;
using UnityEngine;
using Utility;

namespace Blocks
{
	public class Effect : MonoBehaviour
	{
		[SerializeField] private SpriteRenderer spriteRenderer;
		[SerializeField] private float targetScale;
		[SerializeField] private float scaleTime;
		[SerializeField] private float fadeTime;

		private float targetFade = 0f;
		private ObjectPool<Effect> objectPool;

		public void Init(Sprite sprite, ObjectPool<Effect> objectPool)
		{
			transform.localScale = Vector3.zero;
			spriteRenderer.sprite = sprite;
			this.objectPool = objectPool;
		}

		public void PlayAnimation()
		{
			Sequence sequence = DOTween.Sequence();
			sequence.Append(transform.DOScale(targetScale, scaleTime));
			sequence.Append(spriteRenderer.DOFade(targetFade, fadeTime));
			sequence.onComplete += () => objectPool.Release(this);
		}
	}
}
