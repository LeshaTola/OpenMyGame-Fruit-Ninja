using Blocks;
using General;
using MainMenu.StateMachine.States;
using StateMachine.States;
using System.Collections.Generic;
using TNRD;
using UI.SceneTransitions;
using UnityEngine;
using Utility.SceneLoader;

namespace MainMenu.StateMachine

{
	public class MenuStateMachine : MonoBehaviour, IInitable
	{
		[Header("Global")]
		[SerializeField] private int targetFrameRate;
		[SerializeField] private List<Config> blockConfigs;

		[Header("Local")]
		[SerializeField] private SerializableInterface<ISceneTransition> sceneTransition;

		private global::StateMachine.StateMachine core;

		public global::StateMachine.StateMachine Core { get => core; }

		public void Init()
		{
			core = new();

			var localInitState = new InitState(core, sceneTransition.Value);

			core.AddState(new GlobalInitState(core, localInitState, targetFrameRate, blockConfigs));
			core.AddState(localInitState);
			core.AddState(new MainState(core));
			core.AddState(new LoadSceneState(core, sceneTransition.Value, SceneEnum.Gameplay));

			core.SetState<GlobalInitState>();
		}
	}
}
