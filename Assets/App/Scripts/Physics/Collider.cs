using UnityEngine;

namespace Physics
{

	public class Collider : MonoBehaviour
	{
		[SerializeField] private float radius;

		public float Radius { get => radius; set => radius = value; }

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.green;
			Gizmos.DrawWireSphere(transform.position, radius);
		}
	}
}
