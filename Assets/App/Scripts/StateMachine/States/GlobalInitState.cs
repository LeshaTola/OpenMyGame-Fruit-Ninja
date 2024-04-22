using Blocks;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine.States
{
	public class GlobalInitState : State
	{
		public static bool IsComplete = false;

		private State nextState;
		private int targetFrameRate;
		private List<Config> blockConfigs;

		public GlobalInitState(StateMachine stateMachine, State nextState, int targetFrameRate, List<Config> blockConfigs) : base(stateMachine)
		{
			this.nextState = nextState;
			this.targetFrameRate = targetFrameRate;
			this.blockConfigs = blockConfigs;
		}

		public override void Enter()
		{
			base.Enter();
			if (!IsComplete)
			{
				Application.targetFrameRate = targetFrameRate;
				foreach (var config in blockConfigs)
				{
					config.GenerateHalves();
				}
			}
			stateMachine.SetState(nextState.GetType());
		}

		public override void Exit()
		{
			base.Exit();
			IsComplete = true;
		}
	}
}
