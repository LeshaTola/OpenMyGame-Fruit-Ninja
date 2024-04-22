using Assets.App.Scripts.General;
using Physics;
using UnityEngine;

namespace Blocks
{
	public class Block : MonoBehaviour
	{
		[SerializeField] private Config config;
		[SerializeField] private Visual visual;
		[SerializeField] private Movement movement;
		[SerializeField] private MyCollider myCollider;

		public Config Config { get => config; }
		public Visual Visual { get => visual; }
		public Movement Movement { get => movement; }
		public MyCollider Collider { get => myCollider; }
		public Vector2 SliceDirection { get; private set; }

		public void Init(Config config, Context context)
		{
			Init(config, config.BlockSprite, config.Radius, context);
		}

		public void Init(Config config, Sprite sprite, float radius, Context context)
		{
			this.config = config;

			foreach (var component in Config.SliceComponents)
			{
				component.Init(context);
			}
			foreach (var component in Config.KillComponents)
			{
				component.Init(context);
			}

			visual.Init(sprite);
			myCollider.Radius = radius;
		}

		public void ResetBlock()
		{
			visual.RestartAnimation();
			movement.Reset();
		}

		public void Slice(Vector2 delta)
		{
			SliceDirection = delta;
			foreach (var component in Config.SliceComponents)
			{
				component.Execute(this);
			}
		}

		public void Kill()
		{
			foreach (var component in Config.KillComponents)
			{
				component.Execute(this);
			}
		}
	}
}
