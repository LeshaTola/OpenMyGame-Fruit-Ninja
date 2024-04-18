using DG.Tweening;
using Score;
using StateMachine;
using StateMachine.States;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LooseUI : MonoBehaviour
{
	[SerializeField] private ScoreController scoreController;
	[SerializeField] private MonoBehStateMachine stateMachine;

	[SerializeField] private Button restartButton;
	[SerializeField] private Button menuButton;

	[SerializeField] private TextMeshProUGUI scoreText;
	[SerializeField] private TextMeshProUGUI bestScoreText;

	[Header("Animation")]
	[SerializeField] private Image background;
	[SerializeField] private RectTransform content;
	[SerializeField] private float animationTime;

	[SerializeField] private Vector3 ShowScale;
	[SerializeField] private Vector3 HideScale;

	public void Init()
	{
		restartButton.onClick.AddListener(() => stateMachine.StateMachine.SetState<ResetState>());
		menuButton.onClick.AddListener(() => stateMachine.StateMachine.SetState<ResetState>());

		scoreController.OnScoreChanged += OnScoreChanged;
		scoreController.OnBestScoreChanged += OnBestScoreChanged;

		Hide();
	}

	private void OnDestroy()
	{
		scoreController.OnScoreChanged -= OnScoreChanged;
		scoreController.OnBestScoreChanged -= OnBestScoreChanged;
	}

	public void Show()
	{
		gameObject.SetActive(true);
		var sequence = DOTween.Sequence();
		sequence.Append(background.DOFade(1f, animationTime));
		sequence.Append(content.transform.DOScale(ShowScale, animationTime));
	}

	public void Hide()
	{
		var sequence = DOTween.Sequence();
		sequence.Append(content.DOScale(HideScale, animationTime));
		sequence.Append(background.DOFade(0f, animationTime));
		sequence.onComplete += () => gameObject.SetActive(false);
	}

	private void OnBestScoreChanged(int score)
	{
		bestScoreText.text = score.ToString();
	}

	private void OnScoreChanged(int score)
	{
		scoreText.text = score.ToString();
	}
}
