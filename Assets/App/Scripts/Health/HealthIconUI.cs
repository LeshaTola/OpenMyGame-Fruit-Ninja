using DG.Tweening;
using UnityEngine;

public class HealthIconUI : MonoBehaviour
{
	[SerializeField] private Vector3 targetScale;
	[SerializeField] private float animationTime;

	private Vector3 defaultScale;

	public void Init()
	{
		defaultScale = transform.localScale;
	}

	public void Show()
	{
		transform.DOKill();
		gameObject.SetActive(true);
		transform.DOScale(defaultScale, 0f);
	}

	public void Hide()
	{
		transform.DOKill();
		transform.DOScale(targetScale, animationTime);
	}
}
