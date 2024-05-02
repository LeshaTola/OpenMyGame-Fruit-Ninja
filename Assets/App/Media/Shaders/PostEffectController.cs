using UnityEngine;

public class PostEffectController : MonoBehaviour
{
	[SerializeField] private Shader shader;
	[SerializeField] private Color tin;

	private Material postEffectMaterial;
	private RenderTexture postRenderTexture;

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (postRenderTexture == null)
		{
			postEffectMaterial = new Material(shader);
		}
		if (postRenderTexture == null)
		{
			postRenderTexture = new(source.width, source.height, source.depth);
		}
		postEffectMaterial.SetColor("_ScreenTeen", tin);
		Graphics.Blit(source, postRenderTexture, postEffectMaterial, 0);

		Shader.SetGlobalTexture("_GlobalRenderTexture", postRenderTexture);
		Graphics.Blit(source, destination);
	}
}
