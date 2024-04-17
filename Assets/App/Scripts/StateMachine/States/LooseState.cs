using SaveLoad;
using Score;
using System.Collections;
using UnityEngine;

namespace StateMachine.States
{
	public class LooseState : State
	{
		private LooseUI looseUI;
		private ScoreController scoreController;

		public LooseState(StateMachine stateMachine, LooseUI looseUI, ScoreController scoreController) : base(stateMachine)
		{
			this.looseUI = looseUI;
			this.scoreController = scoreController;
		}

		public override void Enter()
		{
			base.Enter();
			looseUI.Show();
			SaveLoadSystem.Save(new SaveData() { BestScore = scoreController.BestScore });
			looseUI.StartCoroutine(RestartCoroutine());
		}

		public IEnumerator RestartCoroutine()
		{
			yield return new WaitForSeconds(3f);
			stateMachine.SetState<ResetState>();
		}

		public override void Exit()
		{
			base.Exit();
			looseUI.Hide();
		}
	}
}
