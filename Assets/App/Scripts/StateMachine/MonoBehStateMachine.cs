using General;
using Health;
using Score;
using Slicing;
using Spawn;
using StateMachine.States;
using System.Collections.Generic;
using TNRD;
using UI;
using UnityEngine;
using Utility.SceneLoader;

namespace StateMachine
{
	public class MonoBehStateMachine : MonoBehaviour
	{
		[SerializeField] private HealthController healthController;
		[SerializeField] private ScoreController scoreController;
		[SerializeField] private Slicer slicer;
		[SerializeField] private ObjectPoolsContainer poolsContainer;
		[SerializeField] private Spawner spawner;
		[SerializeField] private LooseUI looseUI;
		[SerializeField] private PauseUI pauseUI;
		[SerializeField] private List<SerializableInterface<IResettable>> resettables;

		private StateMachine core;

		public StateMachine Core { get => core; }

		public void Init()
		{
			core = new StateMachine();

			core.AddState(new ResetState(core, resettables));
			core.AddState(new GameState(core, healthController, spawner));
			core.AddState(new LooseState(core, looseUI, scoreController, poolsContainer, slicer));
			core.AddState(new PauseState(core, pauseUI, slicer));
			core.AddState(new LoadSceneState(core, SceneEnum.MainMenu));

			core.SetState<ResetState>();
		}
	}
}