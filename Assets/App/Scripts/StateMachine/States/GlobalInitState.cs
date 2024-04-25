using Blocks;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine.States
{
	public class GlobalInitState<T> : State where T : State
	{
		public static bool IsComplete = false;

		private int targetFrameRate;
		private List<Config> blockConfigs;

		public GlobalInitState(StateMachine stateMachine, int targetFrameRate, List<Config> blockConfigs) : base(stateMachine)
		{
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
			stateMachine.SetState<T>();
		}

		public override void Exit()
		{
			base.Exit();
			IsComplete = true;
		}
	}
}
