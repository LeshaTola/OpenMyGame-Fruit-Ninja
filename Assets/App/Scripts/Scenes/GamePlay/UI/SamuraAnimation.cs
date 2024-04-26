using DG.Tweening;
using UnityEngine;

namespace Scenes.GamePlay.UI.Samurai
{
	public class SamuraAnimation : MonoBehaviour
	{
		[SerializeField] private Vector2 hideScale = Vector2.zero;
		[SerializeField] private Vector2 ShowScale = Vector2.one;
		[SerializeField] private float animationTime = 0.5f;

		public void Show()
		{
			transform.DOKill();
			gameObject.SetActive(true);
			transform.DOScale(ShowScale, animationTime);
		}

		public void Hide()
		{
			transform.DOKill();
			transform.DOScale(hideScale, animationTime).onComplete += () => gameObject.SetActive(false);
		}

	}
}