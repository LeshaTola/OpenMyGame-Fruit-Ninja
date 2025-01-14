﻿using Assets.App.Scripts.General;
using Blocks;
using General;
using Spawn;
using StateMachine.States;
using System.Collections.Generic;
using TNRD;
using UI;
using UI.SceneTransitions;
using UnityEngine;

namespace Scenes.GamePlay.StateMachine
{
	public class GamePlayStateMachine : MonoBehaviour, IInitable
	{
		[Header("Global")]
		[SerializeField] private int targetFrameRate;
		[SerializeField] private List<Config> blockConfigs;

		[Header("Local")]
		[SerializeField] private Context context;
		[SerializeField] private Spawner spawner;

		[SerializeField] private SerializableInterface<ISceneTransition> sceneTransition;
		[SerializeField] private LooseUI looseUI;
		[SerializeField] private PauseUI pauseUI;

		[SerializeField] private List<SerializableInterface<IResettable>> resettables;

		private global::StateMachine.StateMachine core;

		public global::StateMachine.StateMachine Core { get => core; }

		public void Init()
		{
			core = new();

			core.AddState(new GlobalInitState<ResetState>(core, targetFrameRate, blockConfigs));
			core.AddState(new States.InitState(core, sceneTransition.Value));
			core.AddState(new ResetState(core, resettables));
			core.AddState(new GameState(core, context.HealthController, spawner));
			core.AddState(new LooseState(core, looseUI, context));
			core.AddState(new PauseState(core, pauseUI, context.Slicer));
			core.AddState(new LoadSceneState(core, sceneTransition.Value));

			core.SetState<GlobalInitState<ResetState>>();
		}
	}
}