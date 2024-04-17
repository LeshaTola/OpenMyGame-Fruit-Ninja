﻿namespace StateMachine.States
{
	public abstract class State
	{
		protected readonly StateMachine stateMachine;

		protected State(StateMachine stateMachine)
		{
			this.stateMachine = stateMachine;
		}

		public virtual void Enter() { }
		public virtual void Exit() { }
		public virtual void Update() { }
	}
}
