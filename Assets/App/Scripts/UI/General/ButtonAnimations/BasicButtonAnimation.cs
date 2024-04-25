using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.General.ButtonAnimations
{
	public class BasicButtonAnimation : ButtonAnimationBase
	{
		[SerializeField] private float AnimationDuration;
		[SerializeField] private Image buttonImage;

		[Header("Scale")]
		[SerializeField] private Vector2 basicScale = Vector2.one;
		[SerializeField] private Vector2 targetScale;

		[Header("Color")]
		[SerializeField] private Color basicColor = Color.white;
		[SerializeField] private Color targetColor = Color.white;

		private Tween scaleTween;
		private Tween colorTween;

		public override void OnPointerDown(PointerEventData eventData)
		{
			base.OnPointerDown(eventData);

			CleanUp();
			transform.DOScale(targetScale, AnimationDuration).SetUpdate(true);
			buttonImage.DOColor(targetColor, AnimationDuration).SetUpdate(true);
		}

		public override void OnPointerUp(PointerEventData eventData)
		{
			base.OnPointerUp(eventData);

			CleanUp();
			transform.DOScale(basicScale, AnimationDuration).SetUpdate(true);
			buttonImage.DOColor(basicColor, AnimationDuration).SetUpdate(true);
		}

		private void CleanUp()
		{
			scaleTween.Kill();
			colorTween.Kill();
		}

	}
}
