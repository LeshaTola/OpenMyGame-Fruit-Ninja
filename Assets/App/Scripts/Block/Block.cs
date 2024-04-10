using UnityEngine;

namespace Block
{

	public class Block : MonoBehaviour
	{
		[SerializeField] private float radius;

		private BlockMovement movement;

		public float Radius { get => radius; }
		public BlockMovement Movement { get => movement; }

		private void Awake()
		{
			movement = new(this);
		}

		private void Update()
		{
			movement.ValidateBoundaries();
			movement.CalculateVelocity();
			movement.Move();
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.green;
			Gizmos.DrawWireSphere(transform.position, radius);
		}
	}
}
