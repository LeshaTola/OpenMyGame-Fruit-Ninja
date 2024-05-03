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
			effectAnimation.PlayShowAnimation();
		}

		public void Hide()
		{
			effectAnimation.PlayHideAnimation();
		}
	}
}