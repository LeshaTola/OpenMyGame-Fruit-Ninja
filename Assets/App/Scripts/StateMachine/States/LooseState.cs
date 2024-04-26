using Assets.App.Scripts.General;
using SaveLoad;
using System.Collections;
using UI;

namespace StateMachine.States
{
	public class LooseState : State
	{
		private LooseUI looseUI;
		private Context context;

		public LooseState(StateMachine stateMachine, LooseUI looseUI, Context context) : base(stateMachine)
		{
			this.looseUI = looseUI;
			this.context = context;
		}

		public override void Enter()
		{
			base.Enter();
			context.Spawner.StopAllCoroutines();
			context.StartCoroutine(PreparingCoroutine());
		}

		public override void Exit()
		{
			base.Exit();
			looseUI.Hide();
		}

		private IEnumerator PreparingCoroutine()
		{
			context.BonusController.CleanUp();
			SaveLoadSystem.Save(new SaveData() { BestScore = context.ScoreController.BestScore });
			context.Slicer.gameObject.SetActive(false);
			while (context.PoolsContainer.Blocks.Active.Count > 0)
			{
				yield return null;
			}
			looseUI.Show();
		}
	}
}
