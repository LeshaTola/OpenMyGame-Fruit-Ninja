using General;
using Scenes.GamePlay.StateMachine;
using StateMachine.States;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour, IInitable
{
	[SerializeField] private PanelAnimation panelAnimation;
	[SerializeField] private GamePlayStateMachine stateMachine;
	[SerializeField] private GameObject pauseBlur;

	[SerializeField] private Button pauseButton;
	[SerializeField] private Button resumeButton;
	[SerializeField] private Button menuButton;

	public void Init()
	{
		pauseButton.onClick.AddListener(() => stateMachine.Core.SetState<PauseState>());
		resumeButton.onClick.AddListener(() => stateMachine.Core.SetState<GameState>());
		menuButton.onClick.AddListener(() =>
		{
			stateMachine.Core.SetState<LoadSceneState>();
			Time.timeScale = 1;
		});
		Hide();
	}

	public void Show()
	{
		Activate();
		pauseBlur.gameObject.SetActive(true);
		panelAnimation.PlayShowAnimation();
	}

	public void Hide()
	{
		Deactivate();
		pauseBlur.gameObject.SetActive(false);
		panelAnimation.PlayHideAnimation();
	}

	private void Activate()
	{
		pauseButton.enabled = false;
		resumeButton.enabled = true;
		menuButton.enabled = true;
	}

	private void Deactivate()
	{
		pauseButton.enabled = true;
		resumeButton.enabled = false;
		menuButton.enabled = false;
	}
}
