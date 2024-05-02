using General;
using UnityEngine;

namespace Scenes.GamePlay.UI.Ice
{
	public class IceEffectUI : MonoBehaviour, IInitable
	{
		[SerializeField] private IceEffectAnimation effectAnimation;
		[SerializeField] private GameObject iceBlur;

		public void Init()
		{
			Hide();
		}

		public void Show()
		{
			gameObject.SetActive(true);
			iceBlur.gameObject.SetActive(true);
			effectAnimation.PlayShowAnimation();
		}

		public void Hide()
		{
			gameObject.SetActive(false);
			iceBlur.gameObject.SetActive(false);
			effectAnimation.PlayHideAnimation();
		}
	}
}