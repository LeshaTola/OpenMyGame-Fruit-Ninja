using Scenes.GamePlay.StateMachine;
using StateMachine.States;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
	[SerializeField] private PanelAnimation panelAnimation;
	[SerializeField] private GamePlayStateMachine stateMachine;

	[SerializeField] private Button pauseButton;
	[SerializeField] private Button resumeButton;
	[SerializeField] private Button menuButton;

	public void Init()
	{
		pauseButton.onClick.AddListener(() => stateMachine.Core.SetState<PauseState>());
		resumeButton.onClick.AddListener(() => stateMachine.Core.SetState<GameState>());
		menuButton.onClick.AddListener(() => stateMachine.Core.SetState<LoadSceneState>());
		Hide();
	}

	public void Show()
	{
		panelAnimation.PlayShowAnimation();
	}

	public void Hide()
	{
		panelAnimation.PlayHideAnimation();
	}
}
