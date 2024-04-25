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

			core.AddState(new GlobalInitState<InitState>(core, targetFrameRate, blockConfigs));
			core.AddState(new InitState(core, sceneTransition.Value));
			core.AddState(new MainState(core));
			core.AddState(new LoadSceneState(core, sceneTransition.Value, SceneEnum.Gameplay));

			core.SetState<GlobalInitState<InitState>>();
		}
	}
}
