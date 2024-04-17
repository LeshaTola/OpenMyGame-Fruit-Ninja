using General;
using Health;
using Score;
using Spawn;
using StateMachine.States;
using System.Collections.Generic;
using TNRD;
using UnityEngine;

namespace StateMachine
{
	public class MonoBehStateMachine : MonoBehaviour
	{
		[SerializeField] private HealthController healthController;
		[SerializeField] private ScoreController scoreController;
		[SerializeField] private Spawner spawner;
		[SerializeField] private LooseUI looseUI;
		[SerializeField] private List<SerializableInterface<IResettable>> resettables;

		private StateMachine stateMachine;

		public void Init()
		{
			stateMachine = new StateMachine();

			stateMachine.AddState(new ResetState(stateMachine, resettables));
			stateMachine.AddState(new GameState(stateMachine, healthController, spawner));
			stateMachine.AddState(new LooseState(stateMachine, looseUI, scoreController));

			stateMachine.SetState<ResetState>();
		}
	}
}