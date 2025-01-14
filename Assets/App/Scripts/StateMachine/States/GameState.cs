﻿using Health;
using Spawn;

namespace StateMachine.States
{
	public class GameState : State
	{
		private HealthController healthController;
		private Spawner spawner;

		public GameState(StateMachine stateMachine, HealthController healthController, Spawner spawner) : base(stateMachine)
		{
			this.healthController = healthController;
			this.spawner = spawner;
		}

		public override void Enter()
		{
			base.Enter();
			healthController.OnDeath += OnDeath;

		}

		public override void Exit()
		{
			base.Exit();
			healthController.OnDeath -= OnDeath;
		}

		private void OnDeath()
		{
			stateMachine.SetState<LooseState>();
		}
	}
}
