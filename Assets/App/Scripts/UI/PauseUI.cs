using StateMachine;
using StateMachine.States;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
	[SerializeField] private PanelAnimation panelAnimation;
	[SerializeField] private MonoBehStateMachine stateMachine;

	[SerializeField] private Button resumeButton;
	[SerializeField] private Button menuButton;

	public void Init()
	{
		resumeButton.onClick.AddListener(() => stateMachine.Core.SetState<GameState>());
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
