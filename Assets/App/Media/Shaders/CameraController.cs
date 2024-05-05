using UnityEngine;

namespace Shaders
{
	public class CameraController : MonoBehaviour
	{
		[SerializeField] private Material mat;
		private int blur = 0;

		void OnRenderImage(RenderTexture src, RenderTexture dest)
		{
			if (blur > 0)
			{
				Graphics.Blit(src, dest, mat);
				return;
			}
			Graphics.Blit(src, dest);
		}

		public void ReduceBlur()
		{
			blur--;
			if (blur < 0)
			{
				blur = 0;
			}
		}

		public void AddBlur()
		{
			blur++;
		}
	}
}