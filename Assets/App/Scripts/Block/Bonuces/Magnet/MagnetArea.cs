using Assets.App.Scripts.General;
using Blocks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetArea : MonoBehaviour
{
	[SerializeField] private float strength;
	[SerializeField] private float radius;
	[SerializeField] private float lifeTime;
	[SerializeField] private Context context;
	[SerializeField] private List<Config> whiteList;

	[SerializeField] private ParticleSystem particles;

	public float Radius { get => radius; }
	public Context Context { get => context; }

	public void Init(float strength, float radius, float lifeTime, Context context, List<Config> whiteList)
	{
		this.strength = strength;
		this.radius = radius;
		this.lifeTime = lifeTime;
		this.context = context;
		this.whiteList = whiteList;
	}

	public void StartPull()
	{
		var particlesMain = particles.main;
		ParticleSystem.ShapeModule shape = particles.shape;
		shape.radius *= radius;
		particlesMain.startLifetime = particlesMain.startLifetime.constant * radius;

		StartCoroutine(PullCoroutine());
	}

	private IEnumerator PullCoroutine()
	{
		float timer = lifeTime;
		while (timer > 0)
		{
			foreach (var block in context.PoolsContainer.Blocks.Active)
			{
				if (!whiteList.Contains(block.Config))
				{
					continue;
				}

				Vector2 pullDirection = transform.position - block.transform.position;
				float distance = pullDirection.magnitude - block.Collider.Radius;
				if (radius < distance)
				{
					continue;
				}
				block.Movement.Reset();
				block.Movement.Push(pullDirection.normalized * strength * distance / radius);
			}
			timer -= Time.deltaTime;
			yield return null;
		}
		Destroy(gameObject);
	}

}
