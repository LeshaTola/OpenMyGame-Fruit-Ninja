using UnityEngine;

namespace Block
{

	public class Block : MonoBehaviour
	{
		[SerializeField] private float radius;

		public float Radius { get => radius; }

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.green;
			Gizmos.DrawWireSphere(transform.position, radius);
		}
	}
}
