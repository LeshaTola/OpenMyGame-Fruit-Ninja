using General;
using System.Collections.Generic;
using TNRD;

namespace StateMachine.States
{
	public class ResetState : State
	{
		List<SerializableInterface<IResettable>> resettables;

		public ResetState(StateMachine stateMachine, List<SerializableInterface<IResettable>> resettables) : base(stateMachine)
		{
			this.resettables = resettables;
		}

		public override void Enter()
		{
			base.Enter();
			foreach (SerializableInterface<IResettable> resettable in resettables)
			{
				resettable.Value.ResetComponent();
			}

			stateMachine.SetState<GameState>();
		}
	}
}
