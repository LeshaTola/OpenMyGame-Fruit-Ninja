using DG.Tweening;
using Shaders;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.GamePlay.UI.Ice
{
	public class IceEffectAnimation : MonoBehaviour
	{
		[SerializeField] private CameraController cameraController;
		[SerializeField] private Image background;
		[SerializeField] private float backgroundFade;
		[SerializeField] private Image vignette;
		[SerializeField] private float vignetteFade;
		[SerializeField] private float animationTime;

		public void PlayShowAnimation()
		{
			cameraController.AddBlur();
			background.DOFade(backgroundFade, animationTime).SetEase(Ease.InOutCirc).SetUpdate(true);
			vignette.DOFade(vignetteFade, animationTime).SetEase(Ease.InOutCirc).SetUpdate(true);
		}

		public void PlayHideAnimation()
		{
			cameraController.ReduceBlur();
			background.DOFade(0f, animationTime).SetEase(Ease.InOutCirc).SetUpdate(true);
			vignette.DOFade(0f, animationTime).SetEase(Ease.InOutCirc).SetUpdate(true);
		}
	}
}
