using DG.Tweening;
using Health;
using UnityEngine;

public class LooseUI : MonoBehaviour
{
	[SerializeField] private HealthController healthController;
	[SerializeField] private float animationTime;

	private Vector3 ShowScale;
	private Vector3 HideScale;

	public void Init()
	{
		ShowScale = transform.localScale;
		HideScale = Vector3.zero;

		Hide();
	}

	public void Show()
	{
		gameObject.SetActive(true);
		transform.DOScale(ShowScale, animationTime);
	}

	public void Hide()
	{
		transform.DOScale(HideScale, animationTime).onComplete += () => gameObject.SetActive(false);
	}
}
