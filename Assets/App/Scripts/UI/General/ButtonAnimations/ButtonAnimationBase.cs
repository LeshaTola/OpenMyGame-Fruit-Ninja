using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.General.ButtonAnimations
{
	public abstract class ButtonAnimationBase : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
	{
		public virtual void OnPointerDown(PointerEventData eventData)
		{
		}

		public virtual void OnPointerUp(PointerEventData eventData)
		{
		}
	}
}
