using DG.Tweening;
using Shaders;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class PanelAnimation : MonoBehaviour
	{

		[SerializeField] private CameraController cameraController;
		[Header("Animation")]
		[SerializeField] private Image background;
		[SerializeField] private RectTransform content;
		[SerializeField] private float animationTime = 0.5f;

		[SerializeField] private float maxFade = 0.9f;
		[SerializeField] private Vector3 ShowScale = Vector3.one;
		[SerializeField] private Vector3 HideScale;

		public void PlayShowAnimation()
		{
			gameObject.SetActive(true);
			cameraController.AddBlur();
			var sequence = DOTween.Sequence();
			sequence.Append(background.DOFade(maxFade, animationTime));
			sequence.Append(content.transform.DOScale(ShowScale, animationTime));
			sequence.SetUpdate(true);
		}

		public void PlayHideAnimation()
		{
			var sequence = DOTween.Sequence();
			cameraController.ReduceBlur();
			sequence.Append(content.DOScale(HideScale, animationTime));
			sequence.Append(background.DOFade(0f, animationTime));
			sequence.SetUpdate(true);
			sequence.onComplete += () => gameObject.SetActive(false);
		}

		private void OnDestroy()
		{
			background.DOKill();
			content.DOKill();
		}
	}
}
