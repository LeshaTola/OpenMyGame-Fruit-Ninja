using Slicing;
using UnityEngine;

namespace StateMachine.States
{
	public class PauseState : State
	{
		private PauseUI pauseUI;
		private Slicer slicer;

		private float startTimeScale = 1f;
		public PauseState(StateMachine stateMachine, PauseUI pauseUI, Slicer slicer) : base(stateMachine)
		{
			this.pauseUI = pauseUI;
			this.slicer = slicer;
		}

		public override void Enter()
		{
			base.Enter();
			pauseUI.Show();
			slicer.gameObject.SetActive(false);
			startTimeScale = Time.timeScale;
			Time.timeScale = 0.0f;
		}

		public override void Exit()
		{
			base.Exit();
			pauseUI.Hide();
			slicer.gameObject.SetActive(true);
			Time.timeScale = startTimeScale;
		}
	}
}
