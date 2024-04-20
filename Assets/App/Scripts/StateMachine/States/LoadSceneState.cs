using DG.Tweening;
using UI.SceneTransitions;
using Utility.SceneLoader;

namespace StateMachine.States
{
	public class LoadSceneState : State
	{
		private SceneEnum scene;
		private ISceneTransition sceneTransition;

		public LoadSceneState(StateMachine stateMachine, ISceneTransition sceneTransition = null, SceneEnum scene = SceneEnum.MainMenu) : base(stateMachine)
		{
			this.sceneTransition = sceneTransition;
			this.scene = scene;
		}

		public override void Enter()
		{
			base.Enter();
			DOTween.KillAll();
			if (sceneTransition != null)
			{
				sceneTransition.PlayOn(() => SceneLoader.LoadScene(scene));
			}
			else
			{
				SceneLoader.LoadScene(scene);
			}
		}
	}
}
