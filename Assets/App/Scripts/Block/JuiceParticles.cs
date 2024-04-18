using System;
using UnityEngine;


public class JuiceParticles : MonoBehaviour
{
	[SerializeField] ParticleSystem particles;

	private Action releaseAction;

	public void Init(Action releaseAction)
	{
		this.releaseAction = releaseAction;
	}

	public void SwapColor(Color color)
	{
		ParticleSystem.MainModule particlesMain = particles.main;
		particlesMain.startColor = color;
	}

	public void Play()
	{
		particles.Play();
	}

	public void OnParticleSystemStopped()
	{
		releaseAction();
	}
}
