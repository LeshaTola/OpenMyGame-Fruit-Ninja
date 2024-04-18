using DG.Tweening;
using TMPro;
using UnityEngine;

public class ComboUI : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI fruitCountText;
	[SerializeField] private TextMeshProUGUI comboText;
	[SerializeField] private RectTransform rectTransform;
	[SerializeField] private Camera mainCamera;

	[Header("Animation")]
	[SerializeField] private float pulsTime = 0.3f;
	[SerializeField] private int pulsCount = 5;
	[SerializeField] private float scaleTime = 0.5f;
	[SerializeField] private float scaleModifier = 1f;
	[SerializeField] private Vector2 minScale = Vector2.zero;
	[SerializeField] private Vector2 maxScale = Vector2.one;

	public void UpdateUI(int fruitCount, int combo)
	{
		fruitCountText.text = $"{fruitCount} фрукта";
		comboText.text = $"x{combo}";
	}

	public void Move(Vector2 position)
	{
		float cameraHeight = mainCamera.orthographicSize;
		float cameraWidth = mainCamera.orthographicSize * mainCamera.aspect;

		float rectHeight = rectTransform.rect.height * maxScale.y;
		float rectWidth = rectTransform.rect.width * maxScale.x;

		float maxMinYPos = cameraHeight - rectHeight / 2;
		float maxMinXPos = cameraWidth - rectWidth / 2;

		float clampedYPosition = Mathf.Clamp(position.y, -maxMinYPos, maxMinYPos);
		float clampedXPosition = Mathf.Clamp(position.x, -maxMinXPos, maxMinXPos);

		transform.position = new Vector2(clampedXPosition, clampedYPosition);
	}

	public void Show()
	{
		transform.DOKill();
		gameObject.SetActive(true);
		Sequence sequence = DOTween.Sequence();
		sequence.Append(transform.DOScale(maxScale, scaleTime));
		sequence.Append(transform.DOScale(scaleModifier, pulsTime).SetLoops(5, LoopType.Yoyo));
		sequence.onComplete += () => Hide();
	}

	public void Hide()
	{
		transform.DOKill();
		transform.DOScale(minScale, scaleTime).onComplete += () => gameObject.SetActive(false);
	}
}
