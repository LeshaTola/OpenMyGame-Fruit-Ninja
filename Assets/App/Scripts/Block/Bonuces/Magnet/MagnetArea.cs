using Assets.App.Scripts.General;
using Blocks;
using Blocks.Configs.Component.Specific;
using System.Collections.Generic;
using UnityEngine;

public class MagnetArea : MonoBehaviour, IBonusComponent
{
	[SerializeField] private float strength;
	[SerializeField] private float radius;
	[SerializeField] private float lifeTime;
	[SerializeField] private Context context;
	[SerializeField] private List<Config> whiteList;

	[SerializeField] private ParticleSystem particles;
	[SerializeField] private SpriteRenderer area;

	private float timer;

	public float Radius { get => radius; }
	public Context Context { get => context; }

	public bool IsValid { get; private set; }

	public void Init(float strength, float radius, float lifeTime, Context context, List<Config> whiteList)
	{
		this.strength = strength;
		this.radius = radius;
		this.lifeTime = lifeTime;
		this.context = context;
		this.whiteList = whiteList;
	}

	public void StartBonus()
	{
		var particlesMain = particles.main;

		ParticleSystem.ShapeModule shape = particles.shape;
		shape.radius *= radius;
		area.transform.localScale = new Vector3(radius, radius, radius);

		particlesMain.startLifetime = particlesMain.startLifetime.constant * radius;
		timer = lifeTime;
		IsValid = true;
	}

	public void UpdateBonus()
	{
		if (timer <= 0)
		{
			IsValid = false;
		}

		timer -= Time.deltaTime;
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
	}

	public void StopBonus()
	{
		Destroy(gameObject);
	}
}
