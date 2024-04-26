using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.GamePlay.UI.Ice
{
	public class IceEffectAnimation : MonoBehaviour
	{
		[SerializeField] private Image background;
		[SerializeField] private float backgroundFade;
		[SerializeField] private Image vignette;
		[SerializeField] private float vignetteFade;
		[SerializeField] private float animationTime;

		public void PlayShowAnimation()
		{
			background.DOFade(backgroundFade, animationTime).SetEase(Ease.InOutCirc).SetUpdate(true);
			vignette.DOFade(vignetteFade, animationTime).SetEase(Ease.InOutCirc).SetUpdate(true);
		}

		public void PlayHideAnimation()
		{
			background.DOFade(0f, animationTime).SetEase(Ease.InOutCirc).SetUpdate(true);
			vignette.DOFade(0f, animationTime).SetEase(Ease.InOutCirc).SetUpdate(true);
		}
	}
}
