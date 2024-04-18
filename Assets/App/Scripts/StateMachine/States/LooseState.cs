using General;
using SaveLoad;
using Score;
using Slicing;
using System.Collections;
using UI;

namespace StateMachine.States
{
	public class LooseState : State
	{
		private LooseUI looseUI;
		private ScoreController scoreController;
		private ObjectPoolsContainer poolsContainer;
		private Slicer slicer;

		public LooseState(StateMachine stateMachine, LooseUI looseUI, ScoreController scoreController, ObjectPoolsContainer poolsContainer, Slicer slicer) : base(stateMachine)
		{
			this.looseUI = looseUI;
			this.scoreController = scoreController;
			this.poolsContainer = poolsContainer;
			this.slicer = slicer;
		}

		public override void Enter()
		{
			base.Enter();
			scoreController.StartCoroutine(PreparingCoroutine());
		}

		public override void Exit()
		{
			base.Exit();
			looseUI.Hide();
		}

		private IEnumerator PreparingCoroutine()
		{
			SaveLoadSystem.Save(new SaveData() { BestScore = scoreController.BestScore });
			slicer.gameObject.SetActive(false);
			while (poolsContainer.Fruits.Active.Count > 0)
			{
				yield return null;
			}
			looseUI.Show();
		}
	}
}
