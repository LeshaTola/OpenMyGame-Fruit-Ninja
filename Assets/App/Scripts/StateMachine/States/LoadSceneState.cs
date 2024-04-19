using Utility.SceneLoader;

namespace StateMachine.States
{
	public class LoadSceneState : State
	{
		private SceneEnum scene;
		public LoadSceneState(StateMachine stateMachine, SceneEnum scene) : base(stateMachine)
		{
			this.scene = scene;
		}

		public override void Enter()
		{
			base.Enter();
			SceneLoader.LoadScene(scene);
		}
	}
}
