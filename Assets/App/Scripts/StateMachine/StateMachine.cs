using StateMachine.States;
using System;
using System.Collections.Generic;

namespace StateMachine
{
	public class StateMachine
	{
		private State currentState;
		private Dictionary<Type, State> states = new();

		public void AddState(State state)
		{
			states.Add(state.GetType(), state);
		}

		public void SetState<T>() where T : State
		{
			var type = typeof(T);

			if (currentState != null && currentState.GetType() == type)
			{
				return;
			}

			if (states.ContainsKey(type))
			{
				currentState?.Exit();

				currentState = states[type];

				currentState.Enter();
			}
		}

		public void Update()
		{
			currentState?.Update();
		}
	}
}
