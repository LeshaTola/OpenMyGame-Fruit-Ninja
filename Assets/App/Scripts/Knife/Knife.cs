using Input;
using Spawn;
using UnityEngine;

namespace Knife
{
	public class Knife : MonoBehaviour
	{
		[SerializeField] private Spawner spawner;
		[SerializeField] private float minSpeed;

		private IPlayerInput playerInput;

		private void Awake()
		{
			playerInput = new MousePlayerInput();
		}

		private void Update()
		{
			var delta = playerInput.GetInputDelta();

			if (delta == null)
			{
				return;
			}

			Vector2 deltaVector = delta.currPos - delta.prevPos;
			if (deltaVector.magnitude < minSpeed)
			{
				return;
			}
			Debug.Log($"Prev: {deltaVector.magnitude}");

			transform.position = delta.currPos;


			foreach (var block in spawner.BlocksPool.Active)
			{
				float distance = MinimumDistance(delta.prevPos, delta.currPos, block.transform.position);
				if (distance <= block.Collider.Radius)
				{
					block.DestroyYourself();
					Debug.Log($"Cut:{block.gameObject.name}");
				}
			}

		}

		public float MinimumDistance(Vector2 start, Vector2 end, Vector2 target)
		{
			float length = (end - start).sqrMagnitude;
			if (length == 0.0f)
				return Vector2.Distance(target, start);

			float t = Mathf.Clamp01(Vector2.Dot(target - start, end - start) / length);
			Vector2 projection = start + t * (end - start);
			return Vector2.Distance(target, projection);
		}
	}
}