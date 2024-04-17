using DG.Tweening;
using Health;
using UnityEngine;

public class LooseUI : MonoBehaviour
{
	[SerializeField] private HealthController healthController;
	[SerializeField] private float animationTime;

	private Vector3 targetScale;

	public void Init()
	{
		targetScale = transform.localScale;
		transform.localScale = Vector3.zero;

		gameObject.SetActive(false);

		healthController.OnDeath += OnDeath;
	}

	private void OnDestroy()
	{
		healthController.OnDeath -= OnDeath;
	}

	private void OnDeath()
	{
		Show();
	}

	public void Show()
	{
		gameObject.SetActive(true);
		transform.DOScale(targetScale, animationTime);
	}
}
