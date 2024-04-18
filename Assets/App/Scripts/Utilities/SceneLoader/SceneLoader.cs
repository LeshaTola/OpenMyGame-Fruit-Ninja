using UnityEngine.SceneManagement;
namespace Utility.SceneLoader
{
	public enum SceneEnum
	{
		Gameplay,
		MainMenu
	}

	public class SceneLoader
	{
		public static void LoadScene(SceneEnum scene)
		{
			SceneManager.LoadScene(scene.ToString());
		}
	}
}