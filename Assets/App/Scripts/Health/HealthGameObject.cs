using DG.Tweening;
using UnityEngine;

namespace Health
{
	public class HealthGameObject : MonoBehaviour
	{
		[SerializeField] SpriteRenderer spriteRenderer;

		public void Hide()
		{
			spriteRenderer.DOFade(0f, 0.1f).onComplete += () => Destroy(gameObject);

		}
	}
}
