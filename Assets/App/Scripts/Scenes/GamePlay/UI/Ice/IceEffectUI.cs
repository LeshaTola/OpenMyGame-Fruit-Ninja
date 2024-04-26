using General;
using UnityEngine;

namespace Scenes.GamePlay.UI.Ice
{
	public class IceEffectUI : MonoBehaviour, IInitable
	{
		[SerializeField] private IceEffectAnimation effectAnimation;

		public void Init()
		{
			Hide();
		}

		public void Show()
		{
			gameObject.SetActive(true);
			effectAnimation.PlayShowAnimation();
		}

		public void Hide()
		{
			gameObject.SetActive(false);
			effectAnimation.PlayHideAnimation();
		}
	}
}