using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class PanelAnimation : MonoBehaviour
	{

		[Header("Animation")]
		[SerializeField] private Image background;
		[SerializeField] private RectTransform content;
		[SerializeField] private float animationTime = 0.5f;

		[SerializeField] private Vector3 ShowScale = Vector3.one;
		[SerializeField] private Vector3 HideScale;

		public void PlayShowAnimation()
		{
			gameObject.SetActive(true);
			var sequence = DOTween.Sequence();
			sequence.Append(background.DOFade(1f, animationTime));
			sequence.Append(content.transform.DOScale(ShowScale, animationTime));
		}

		public void PlayHideAnimation()
		{
			var sequence = DOTween.Sequence();
			sequence.Append(content.DOScale(HideScale, animationTime));
			sequence.Append(background.DOFade(0f, animationTime));
			sequence.onComplete += () => gameObject.SetActive(false);
		}

		private void OnDestroy()
		{
			background.DOKill();
			content.DOKill();
		}
	}
}
